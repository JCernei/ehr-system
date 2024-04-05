using System.Security.Claims;
using Application.Commands.CreateLabResult;
using Application.Queries.GetLabResultById;
using Application.Queries.GetLabResults;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Common;
using Shared;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LabResultsController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly ILogger<LabResultsController> logger;


    public LabResultsController(IMediator mediator, ILogger<LabResultsController> logger)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        ArgumentNullException.ThrowIfNull(logger);
        this.mediator = mediator;
        this.logger = logger;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<LabResultDto>>> GetAll()
    {
        var userId = Guid.Parse("7e743b6e-e5ab-4a23-8138-9c0f3fe55049");
        var query = new GetLabResultsQuery
        {
            UserId = userId
        };
        var labResults = await mediator.Send(query);
        var labResultsDtos = labResults.Select(Mapper.Map).ToList();
        logger.LogInformation("Lab results retrieved: {LabResults}", labResultsDtos);
        return labResultsDtos;
    }
 
    [HttpGet("{id}")]
    public async Task<ActionResult<LabResultDto>> GetById(Guid id)
    {
        var query = new GetLabResultByIdQuery { Id = id };
        var labResult = await mediator.Send(query);
        var labResultDto = Mapper.Map(labResult);
        
        if (labResultDto == null)
        {
            return NotFound();
        }

        return labResultDto;
    }

    [HttpPost]
    public async Task<ActionResult<LabResultDto>> Create([FromForm] IEnumerable<IFormFile> files, LabResultDto labResultDto)
    {
        var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == "userId");
        
        if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
            return BadRequest("UserId invalid");
        
        var roles = User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();
        
        if (!roles.Contains("LabTechnician"))
            return BadRequest("User is not a lab technician");

        var command = new CreateLabResultCommand
        {
            Files = files,
            PatientId = labResultDto.PatientId,
            LabTechnicianId = userId,
            TestName = labResultDto.TestName,
        };
        
        var result = await mediator.Send(command);
        return result.IsSuccessful ? Ok() : BadRequest(result.Error);
    }
    
    // [HttpPut("{id}")]
    // public async Task<IActionResult> Update(int id, [FromBody] UpdateLabResultCommand command)
    // {
    //     if (id != command.LabResultId)
    //     {
    //         return BadRequest();
    //     }
    //
    //     await mediator.Send(command);
    //
    //     return NoContent();
    // }
    //
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> Delete(int id)
    // {
    //     var command = new DeleteLabResultCommand { LabResultId = id };
    //     await mediator.Send(command);
    //
    //     return NoContent();
    // }
}

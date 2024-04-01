using System.Security.Claims;
using Application.Commands.CreateLabResult;
using Application.Queries.GetFiles;
using Application.Queries.GetLabResultById;
using Application.Queries.GetLabResults;
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
    [Route("/api/lab-results")]
    public async Task<List<LabResultDto>> GetAllByUserId()
    {
        var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == "userId");
        if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
            throw new InvalidOperationException("UserId invalid");
        
        var query = new GetLabResultsQuery
        {
            UserId = userId
        };
        var labResults = await mediator.Send(query);
        var labResultsDtos = labResults.Select(Mapper.Map).ToList();
        logger.LogInformation("Lab results retrieved: {LabResults}", labResultsDtos);
        return labResultsDtos;
    }
    
    [HttpGet]
    [Route("/api/{patientId}/lab-results")]
    public async Task<List<LabResultDto>> GetAllByPatientId(Guid patientId)
    {
        // var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == "userId");
        // if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
        //     throw new InvalidOperationException("UserId invalid");
        
        // if (!Guid.TryParse(patientId, out Guid patientId))
        //     throw new InvalidOperationException("PatientId invalid");
        
        var roles = User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();
        
        if (!roles.Contains("Doctor"))
            throw new InvalidOperationException("User is not a Doctor");
        
        var query = new GetLabResultsQuery()
        {
            UserId = patientId
        };
        
        var labResults = await mediator.Send(query);
        var labResultsDtos = labResults.Select(Mapper.Map).ToList();
        logger.LogInformation("Lab results retrieved: {LabResults}", labResultsDtos);
        return labResultsDtos;
    }
    
    [HttpGet("/api/{patientId}/lab-results/{labResultId}")]
    public async Task<LabResultDto> GetById(Guid patientId, Guid labResultId)
    {
        // if (!Guid.TryParse(id, out Guid patientId))
        //     throw new InvalidOperationException("PatientId invalid");
        
        var roles = User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();
        
        // if (!roles.Contains("Doctor"))
        //     throw new InvalidOperationException("User is not a Doctor");
        
        var labResultQuery = new GetLabResultByIdQuery
        {
            PatientId = patientId,
            LabResultId = labResultId
        };
        
        var labResult = await mediator.Send(labResultQuery);
        
        var labResultDto = Mapper.Map(labResult);
        return labResultDto;
    }
    
    [HttpGet("/api/lab-results/{labResultId}")]
    public async Task<LabResultDto> GetById(Guid labResultId)
    {
        var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == "userId");
        if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
            throw new InvalidOperationException("UserId invalid");
        
        var labResultQuery = new GetLabResultByIdQuery
        {
            PatientId = userId,
            LabResultId = labResultId
        };
        
        var labResult = await mediator.Send(labResultQuery);
        
        var labResultDto = Mapper.Map(labResult);
        return labResultDto;
    }
    
    [HttpGet("/api/{patientId}/lab-results/{labResultId}/download")]
    public async Task<IActionResult> GetFiles(Guid patientId, Guid labResultId)
    {
        // if (!Guid.TryParse(id, out Guid patientId))
        //     throw new InvalidOperationException("PatientId invalid");
        
        var roles = User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();
        
        if (!roles.Contains("Doctor"))
            throw new InvalidOperationException("User is not a Doctor");
        
        var labResultQuery = new GetLabResultByIdQuery
        {
            PatientId = patientId,
            LabResultId = labResultId
        };
        
        var labResult = await mediator.Send(labResultQuery);
        
        var filesQuery = new GetFilesQuery
        {
            FilePaths = labResult.FilePaths
        };
        
        var files = await mediator.Send(filesQuery);
        
        return File(files[0], "application/octet-stream");
    }
    
    [HttpGet("/api/lab-results/{labResultId}/download")]
    public async Task<IActionResult> GetFiles(Guid labResultId)
    {
        var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == "userId");
        if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
            throw new InvalidOperationException("UserId invalid");
        
        var labResultQuery = new GetLabResultByIdQuery
        {
            PatientId = userId,
            LabResultId = labResultId
        };
        
        var labResult = await mediator.Send(labResultQuery);
        
        var filesQuery = new GetFilesQuery
        {
            FilePaths = labResult.FilePaths
        };
        
        var files = await mediator.Send(filesQuery);
        
        return File(files[0], "application/octet-stream");
    }

    [HttpPost]
    public async Task<ActionResult<LabResultDto>> Create([FromForm] LabResultDto labResultDto)
    {
        var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == "userId");
        if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
            return BadRequest("UserId invalid");
        
        if (!Guid.TryParse(labResultDto.PatientId, out Guid patientId))
            return BadRequest("PatientId invalid");
        
        var roles = User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();
        
        if (!roles.Contains("LabTechnician"))
            return BadRequest("User is not a lab technician");

        var command = new CreateLabResultCommand
        {
            Files = labResultDto.Files.Select(x => x.OpenReadStream()),
            PatientId = patientId,
            LabTechnicianId = userId,
            TestName = labResultDto.TestName,
            FileNames = labResultDto.Files.Select(x => x.FileName).ToList(),
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

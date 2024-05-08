using System.Security.Claims;
using Application.Commands.PostConsultation;
using Application.Queries.GetConsultations;
using Application.Queries.GetConsultationsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Common;
using Shared;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsultationsController : ControllerBase
{
    private readonly ILogger<ConsultationsController> logger;
    private readonly IMediator mediator;

    public ConsultationsController(IMediator mediator, ILogger<ConsultationsController> logger)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        this.mediator = mediator;
        this.logger = logger;
    }

    [HttpGet]
    public async Task<List<ConsultationResponseDto>> GetAll()
    {
        var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == "userId");
        if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
            throw new InvalidOperationException("UserId invalid");

        var query = new GetConsultationsQuery { UserId = userId };
        var consultations = await mediator.Send(query);

        var consultationDtos = consultations.Select(Mapper.Map).ToList();

        return consultationDtos;
    }

    [HttpGet]
    [Route("/api/{userId}/consultations")]
    public async Task<List<ConsultationResponseDto>> GetAllByUserId(Guid userId)
    {
        var query = new GetConsultationsByUserIdQuery { UserId = userId };
        var consultations = await mediator.Send(query);
        var consultationDtos = consultations.Select(Mapper.Map).ToList();
        return consultationDtos;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ConsultationRequestDto consultationDto)
    {
        var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == "userId");
        if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
            return BadRequest("UserId invalid");
        if (!Guid.TryParse(consultationDto.PatientId, out var patientId))
            return BadRequest("PatientId invalid");
        var roles = User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();
        if (!roles.Contains("Doctor"))
            return BadRequest("User is not a doctor");
        var command = new PostConsultationCommand
        {
            PatientId = patientId,
            DoctorId = userId,
            Description = consultationDto.Description
        };

        var result = await mediator.Send(command);

        return result.IsSuccessful ? Ok() : BadRequest(result.Error);
    }
}

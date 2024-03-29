using Application.Queries.GetConsultations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Common;
using Shared;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsultationsController : ControllerBase
{
    private readonly IMediator mediator;

    public ConsultationsController(IMediator mediator)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<ConsultationDto>> GetAll()
    {
        var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == "userId");
        if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
            throw new InvalidOperationException("UserId invalid");

        var query = new GetConsultationsQuery
        {
            UserId = userId
        };
        var consultations = await mediator.Send(query);

        var consultationDtos = consultations.Select(Mapper.Map).ToList();

        return consultationDtos;
    }
}

using Application.Queries.GetUserById;
using Application.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Common;
using Shared;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator mediator;

    public UsersController(IMediator mediator)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<UserDto>> GetAll()
    {
        var query = new GetUsersQuery();
        var users = await mediator.Send(query);
        var userDtos = users.Select(Mapper.Map).ToList();
        return userDtos;
    }

    [HttpGet("{id}")]
    public async Task<UserDto> GetById(Guid id)
    {
        var query = new GetUserByIdQuery { Id = id };
        var user = await mediator.Send(query);
        var userDto = Mapper.Map(user);
        return userDto;
    }
}

using Application.Commands.LoginUser;
using Application.Commands.RegisterUser;
using Application.Queries.GetUserDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Common;
using Server.Common.JwtToken;
using Shared;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly JwtService jwtService;
    private readonly IMediator mediator;

    public AccountController(IMediator mediator, JwtService jwtService)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        ArgumentNullException.ThrowIfNull(jwtService);

        this.mediator = mediator;
        this.jwtService = jwtService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var registerCommand = new RegisterUserCommand
        {
            Idnp = dto.Idnp,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Password = dto.Password,
            Roles = dto.Roles
        };

        var result = await mediator.Send(registerCommand);
        return result.IsSuccessful ? Ok() : BadRequest(new { result.Error });
    }


    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var loginCommand = new LoginUserCommand
        {
            Idnp = dto.Idnp,
            Password = dto.Password
        };

        var result = await mediator.Send(loginCommand);

        if (!result.IsSuccessful)
            return BadRequest(result.Error);

        var userDetailsQuery = new GetUserDetailsQuery
        {
            Idnp = dto.Idnp
        };

        var userDetails = await mediator.Send(userDetailsQuery);

        var jwtToken = jwtService.CreateAuthToken(userDetails.Id, userDetails.Roles);

        Response.Cookies.Append(Constants.TokenCookieName, jwtToken, new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTimeOffset.MaxValue
        });

        return Ok(jwtToken);
    }
}

using MediatR;

namespace Application.Commands.LoginUser;

public class LoginUserCommand : IRequest<CommandStatus>
{
    public string Idnp { get; set; }
    public string Password { get; set; }
}

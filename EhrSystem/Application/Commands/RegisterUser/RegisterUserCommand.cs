using MediatR;

namespace Application.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<CommandStatus>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Idnp { get; set; }
    public string Password { get; set; }
}

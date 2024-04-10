using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands.LoginUser;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, CommandStatus>
{
    private readonly SignInManager<User> signInManager;
    private readonly UserManager<User> userManager;

    public LoginUserHandler(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        ArgumentNullException.ThrowIfNull(userManager);
        ArgumentNullException.ThrowIfNull(signInManager);

        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    public async Task<CommandStatus> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.Idnp);

        if (user is null)
            return CommandStatus.Failed("User does not exists");

        var passwordStatus = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!passwordStatus.Succeeded)
            return CommandStatus.Failed("Wrong password");

        return new CommandStatus();
    }
}

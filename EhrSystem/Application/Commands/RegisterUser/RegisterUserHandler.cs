using Domain.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.RegisterUser;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, CommandStatus>
{
    private readonly ApplicationDbContext context;
    private readonly UserManager<User> userManager;

    public RegisterUserHandler(ApplicationDbContext context, UserManager<User> userManager)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(userManager);

        this.context = context;
        this.userManager = userManager;
    }

    public async Task<CommandStatus> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await context.Users.AnyAsync(user => user.Idnp == request.Idnp, cancellationToken);
        if (userExists)
            return CommandStatus.Failed("User already exists");

        var roles = request.Roles;
        var user = new User
        {
            Id = Guid.NewGuid(),
            Idnp = request.Idnp,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.Idnp
        };

        var createResult = await userManager.CreateAsync(user, request.Password);
        if (!createResult.Succeeded)
            return CommandStatus.Failed("The user could not be created");

        var roleResult = await userManager.AddToRolesAsync(user, roles);
        if (!roleResult.Succeeded)
            return CommandStatus.Failed("The user could not be registered");

        return new CommandStatus();
    }
}

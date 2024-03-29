using Domain.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Queries.GetUserDetails;

public class GetUserDetailsHandler : IRequestHandler<GetUserDetailsQuery, UserDetails>
{
    private readonly UserManager<User> userManager;

    public GetUserDetailsHandler(UserManager<User> userManager)
    {
        ArgumentNullException.ThrowIfNull(userManager);

        this.userManager = userManager;
    }

    public async Task<UserDetails> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.Idnp);

        if (user is null)
            return new UserDetails();

        var roleStrings = await userManager.GetRolesAsync(user);

        return new UserDetails
        {
            Id = user.Id.ToString(),
            Roles = roleStrings.ToArray(),
            Idnp = request.Idnp
        };
    }
}

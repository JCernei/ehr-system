using Domain.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetUsers;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<User>>
{
    private readonly ApplicationDbContext context;

    public GetUsersHandler(ApplicationDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this.context = context;
    }

    public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await context.Users
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return users;
    }
}

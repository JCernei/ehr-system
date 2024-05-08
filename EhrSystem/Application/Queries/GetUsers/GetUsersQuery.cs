using Domain.Models;
using MediatR;

namespace Application.Queries.GetUsers;

public class GetUsersQuery : IRequest<List<User>>;

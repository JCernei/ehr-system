using Domain.Models;
using MediatR;

namespace Application.Queries.GetUserById;
public class GetUserByIdQuery : IRequest<User>
{
   public Guid Id { get; set; }
}

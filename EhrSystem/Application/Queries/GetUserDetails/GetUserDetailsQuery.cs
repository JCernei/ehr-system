using Domain.Dtos;
using MediatR;

namespace Application.Queries.GetUserDetails;

public class GetUserDetailsQuery : IRequest<UserDetails>
{
    public string Idnp { get; set; }
}

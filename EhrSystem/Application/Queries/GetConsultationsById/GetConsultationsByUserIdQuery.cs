using Domain.Models;
using MediatR;

namespace Application.Queries.GetConsultationsById;

public class GetConsultationsByUserIdQuery : IRequest<List<Consultation>>
{
    public Guid UserId { get; set; }
}

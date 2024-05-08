using Domain.Models;
using MediatR;

namespace Application.Queries.GetConsultations;

public class GetConsultationsQuery : IRequest<List<Consultation>>
{
    public Guid UserId { get; set; }
}

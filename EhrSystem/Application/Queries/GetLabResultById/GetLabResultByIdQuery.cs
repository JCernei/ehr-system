using Domain.Models;
using MediatR;

namespace Application.Queries.GetLabResultById;

public class GetLabResultByIdQuery : IRequest<LabResult>
{
    public Guid Id { get; set; }
}
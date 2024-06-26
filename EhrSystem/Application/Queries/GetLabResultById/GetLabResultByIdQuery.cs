using Domain.Models;
using MediatR;

namespace Application.Queries.GetLabResultById;

public class GetLabResultByIdQuery : IRequest<LabResult>
{
    public Guid PatientId { get; set; }
    public Guid LabResultId { get; set; }
}

using Domain.Models;
using MediatR;

namespace Application.Queries.GetLabResults;

public class GetLabResultsQuery : IRequest<List<LabResult>>
{
    public Guid UserId { get; set; }
}

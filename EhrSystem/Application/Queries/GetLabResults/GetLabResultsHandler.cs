using Domain.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Queries.GetLabResults;

public class GetLabResultsHandler : IRequestHandler<GetLabResultsQuery, List<LabResult>>
{
    private readonly ApplicationDbContext dbContext;

    public GetLabResultsHandler(ApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        this.dbContext = dbContext;
    }

    public async Task<List<LabResult>> Handle(GetLabResultsQuery request, CancellationToken cancellationToken)
    {
        var labResults = await dbContext.LabResults
            // .Include(x => x.Patient)
            // .Include(x => x.Doctor)
            .Where(x => x.PatientId == request.UserId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        return labResults;
    }
}
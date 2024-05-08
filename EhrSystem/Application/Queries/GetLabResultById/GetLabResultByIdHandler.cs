using Domain.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetLabResultById;

public class GetLabResultByIdHandler : IRequestHandler<GetLabResultByIdQuery, LabResult>
{
    private readonly ApplicationDbContext dbContext;

    public GetLabResultByIdHandler(ApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        this.dbContext = dbContext;
    }

    public async Task<LabResult> Handle(GetLabResultByIdQuery request, CancellationToken cancellationToken)
    {
        var labResult = await dbContext.LabResults
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.PatientId == request.PatientId && x.Id == request.LabResultId, cancellationToken);

        return labResult;
    }
}

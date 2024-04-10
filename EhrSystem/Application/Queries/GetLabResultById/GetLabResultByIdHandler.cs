using AutoMapper;
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
        this.dbContext = dbContext;
    }

    public async Task<LabResult> Handle(GetLabResultByIdQuery request, CancellationToken cancellationToken)
    {
        var labResult = await dbContext.LabResults
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return labResult;
    }
}
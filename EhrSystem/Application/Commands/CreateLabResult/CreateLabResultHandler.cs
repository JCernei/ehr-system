using AutoMapper;
using Domain.Models;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.CreateLabResult;

public class CreateLabResultHandler : IRequestHandler<CreateLabResultCommand, LabResult>
{
    private readonly ApplicationDbContext dbContext;

    public CreateLabResultHandler(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<LabResult> Handle(CreateLabResultCommand request, CancellationToken cancellationToken)
    {
        var labResult = request.LabResult;
        dbContext.LabResults.Add(labResult);
        await dbContext.SaveChangesAsync(cancellationToken);
        return labResult;
    }
}
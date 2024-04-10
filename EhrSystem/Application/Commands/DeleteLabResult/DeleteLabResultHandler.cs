using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.DeleteLabResult;

public class DeleteLabResultHandler : IRequestHandler<DeleteLabResultCommand, CommandStatus>
{
    private readonly ApplicationDbContext dbContext;

    public DeleteLabResultHandler(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<CommandStatus> Handle(DeleteLabResultCommand request, CancellationToken cancellationToken)
    {
        var labResult = await dbContext.LabResults.FindAsync(request.LabResultId);
        if (labResult == null)
        {
            throw new InvalidOperationException($"LabResult with ID {request.LabResultId} not found.");
        }

        dbContext.LabResults.Remove(labResult);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CommandStatus();
    }
}
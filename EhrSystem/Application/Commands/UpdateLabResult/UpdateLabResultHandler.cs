using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.UpdateLabResult;

public class UpdateLabResultHandler : IRequestHandler<UpdateLabResultCommand, CommandStatus>
{
    private readonly ApplicationDbContext dbContext;

    public UpdateLabResultHandler(ApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        this.dbContext = dbContext;
    }

    public async Task<CommandStatus> Handle(UpdateLabResultCommand request, CancellationToken cancellationToken)
    {
        var labResult = await dbContext.LabResults.FindAsync(request.LabResultId);
        if (labResult == null)
            throw new InvalidOperationException($"LabResult with ID {request.LabResultId} not found.");

        await dbContext.SaveChangesAsync(cancellationToken);

        return new CommandStatus();
    }
}

using MediatR;

namespace Application.Commands.DeleteLabResult;

public class DeleteLabResultCommand : IRequest<CommandStatus>
{
    public int LabResultId { get; set; }
}
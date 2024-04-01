using MediatR;

namespace Application.Commands.DeleteLabResult;

public class DeleteLabResultCommand : IRequest
{
    public int LabResultId { get; set; }
}
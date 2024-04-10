using Domain.Models;
using MediatR;

namespace Application.Commands.UpdateLabResult;

public class UpdateLabResultCommand : IRequest<CommandStatus>
{
    public int LabResultId { get; set; }
    public LabResult LabResult { get; set; }
}
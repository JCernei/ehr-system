using Domain.Models;
using MediatR;
using Shared;

namespace Application.Commands.CreateLabResult;

public class CreateLabResultCommand : IRequest<LabResult>
{
    public LabResult LabResult { get; set; }
}
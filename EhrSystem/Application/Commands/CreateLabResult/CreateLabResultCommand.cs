using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.CreateLabResult;

public class CreateLabResultCommand : IRequest<CommandStatus>
{
    public IEnumerable<IFormFile> Files { get; set; }
    public Guid PatientId { get; set; }
    public Guid LabTechnicianId { get; set; }
    public string TestName { get; set; }
    public string FilePath { get; set; }
}
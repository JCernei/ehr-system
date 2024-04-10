using Microsoft.AspNetCore.Http;

namespace Shared;

public class LabResultDto
{
    public string PatientId { get; set; }
    public string LabTechnicianId { get; set; }
    public string TestName { get; set; }
    public IEnumerable<IFormFile> Files { get; set; }
    public string FilePath { get; set; }
}
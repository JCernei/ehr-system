using Microsoft.AspNetCore.Http;

namespace Shared;

public class LabResultRequestDto
{
    public string PatientId { get; set; }

    // public string LabTechnicianId { get; set; }
    public string TestName { get; set; }
    public IEnumerable<IFormFile> Files { get; set; }
}

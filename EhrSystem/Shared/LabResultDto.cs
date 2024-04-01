using Microsoft.AspNetCore.Http;

namespace Shared;

public class LabResultDto
{
    public string Id { get; set; }
    public string PatientId { get; set; }
    // public string LabTechnicianId { get; set; }
    public string TestName { get; set; }
    public IEnumerable<IFormFile> Files { get; set; }
    public string FileType { get; set; }
    public DateTime TimeStamp { get; set; }
    // public List<string> FilePaths { get; set; }
}
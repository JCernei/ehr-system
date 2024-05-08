using Domain.Common;

namespace Domain.Models;

public class LabResult : BaseEntity
{
    public Guid PatientId { get; set; }
    public Guid LabTechnicianId { get; set; }
    public string TestName { get; set; }
    public List<string> FilePaths { get; set; }
}

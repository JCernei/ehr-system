using Domain.Common;

namespace Domain.Models;

public class LabResult : BaseEntity
{
    public Guid PatientId { get; set; }
    public Guid LabTechnicianId { get; set; }
    public string TestName { get; set; }
    public string FilePath { get; set; }
}
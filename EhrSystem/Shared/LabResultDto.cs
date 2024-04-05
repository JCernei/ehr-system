namespace Shared;

public class LabResultDto
{
    public Guid PatientId { get; set; }
    public Guid LabTechnicianId { get; set; }
    public string TestName { get; set; }
    public string FilePath { get; set; }
}
namespace Shared;

public class LabResultResponseDto
{
    public string Id { get; set; }
    public string PatientId { get; set; }

    // public string LabTechnicianId { get; set; }
    public string TestName { get; set; }
    public string FileType { get; set; }
    public DateTime TimeStamp { get; set; }
}

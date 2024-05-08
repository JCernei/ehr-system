namespace Shared;

public class LabResultDescriptionDto
{
    public Guid PatientId { get; set; }
    public Guid LabResultId { get; set; }
    public Guid DoctorId { get; set; }
    public string Description { get; set; }
}

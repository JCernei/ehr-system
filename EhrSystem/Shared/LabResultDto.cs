namespace Shared;

public class LabResultDto
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public string TestName { get; set; }
    public string Result { get; set; }
    public string ImagePath { get; set; }
    public string PdfPath { get; set; }
    public DateTime TimeStamp { get; set; }  // Date of the lab result
}
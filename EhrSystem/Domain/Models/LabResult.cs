using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Models;

public class LabResult : BaseEntity
{
    [ForeignKey("Patient")]
    public Guid PatientId { get; set; }
    public string TestName { get; set; }
    public string Result { get; set; }
    public string ImagePath { get; set; }
    public string PdfPath { get; set; }

    // Navigation property for Patient
    public User Patient { get; set; }
}
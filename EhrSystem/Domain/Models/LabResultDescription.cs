using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Models;

public class LabResultDescription : BaseEntity
{
    [ForeignKey("LabResult, Patient")]
    public Guid PatientId { get; set; }
    public Guid LabResultId { get; set; }
    public Guid DoctorId { get; set; }
    public string Description { get; set; }

    // Navigation property for Patient and LabResult
    public User Patient { get; set; }
    public LabResult LabResult { get; set; }
}

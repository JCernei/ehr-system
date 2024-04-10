using Domain.Common;

namespace Domain.Models;

public class Consultation : BaseEntity
{
    public Guid PatientId { get; set; }
    public User Patient { get; set; }
    public Guid DoctorId { get; set; }
    public User Doctor { get; set; }
    public string Description { get; set; }
}

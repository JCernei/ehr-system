using Domain.Common;

namespace Domain.Models;

public class Consultation : BaseEntity
{
    public User Patient { get; set; }
    public User Doctor { get; set; }
    public string Description { get; set; }
}

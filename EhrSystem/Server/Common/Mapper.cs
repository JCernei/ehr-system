using Domain.Models;
using Shared;

namespace Server.Common;

public static class Mapper
{
    public static ConsultationDto Map(Consultation source)
    {
        return new ConsultationDto
        {
            PatientId = source.Patient.Id.ToString(),
            Description = source.Description
        };
    }
    public static UserDto Map(User source)
    {
        return new UserDto
        {
            Id = source.Id.ToString(),
            Idnp = source.Idnp,
            FirstName = source.FirstName,
            LastName = source.LastName,
        };
    }
}

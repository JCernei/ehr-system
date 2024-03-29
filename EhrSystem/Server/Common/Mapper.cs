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
}

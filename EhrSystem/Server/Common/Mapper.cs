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
    
    public static LabResultDto Map(LabResult source)
    {
        return new LabResultDto
        {
            Id = source.Id,
            PatientId = source.PatientId,
            TestName = source.TestName,
            Result = source.Result,
            ImagePath = source.ImagePath,
            PdfPath = source.PdfPath,
            TimeStamp = source.TimeStamp
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

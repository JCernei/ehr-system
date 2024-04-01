using Domain.Models;
using Shared;

namespace Server.Common;

public static class Mapper
{
    public static ConsultationDto Map(Consultation source)
    {
        return new ConsultationDto
        {
            DoctorId = source.DoctorId.ToString(),
            PatientId = source.Patient.Id.ToString(),
            Description = source.Description,
            TimeStamp = source.TimeStamp
        };
    }
    
    public static LabResultDto Map(LabResult source)
    {
        return new LabResultDto
        {
            // PatientId = source.PatientId.ToString(),
            // LabTechnicianId = source.LabTechnicianId.ToString(),
            Id = source.Id.ToString(),
            TestName = source.TestName,
            FileType = Path.GetExtension(source.FilePaths[0]),
            TimeStamp = source.TimeStamp,
            // FilePath = source.FilePaths,
        };
    }

    public static LabResultDescriptionDto Map(LabResultDescription source)
    {
        return new LabResultDescriptionDto()
        {
            PatientId = source.PatientId,
            LabResultId = source.LabResultId,
            DoctorId = source.DoctorId,
            Description = source.Description,
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

using MediatR;

namespace Application.Commands.PostConsultation;

public class PostConsultationCommand : IRequest<CommandStatus>
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public string Description { get; set; }
}

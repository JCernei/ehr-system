using Domain.Models;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.PostConsultation;

public class PostConsultationHandler : IRequestHandler<PostConsultationCommand, CommandStatus>
{
    private readonly ApplicationDbContext context;

    public PostConsultationHandler(ApplicationDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        this.context = context;
    }

    public async Task<CommandStatus> Handle(PostConsultationCommand request, CancellationToken cancellationToken)
    {
        var consultation = new Consultation
        {
            PatientId = request.PatientId,
            DoctorId = request.DoctorId,
            Description = request.Description
        };

        await context.Consultations.AddAsync(consultation, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new CommandStatus();
    }
}

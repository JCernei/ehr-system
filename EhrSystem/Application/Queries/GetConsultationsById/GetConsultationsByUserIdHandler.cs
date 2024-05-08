using Domain.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetConsultationsById;

public class GetConsultationsByUserIdHandler : IRequestHandler<GetConsultationsByUserIdQuery, List<Consultation>>
{
    private readonly ApplicationDbContext context;

    public GetConsultationsByUserIdHandler(ApplicationDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this.context = context;
    }

    public async Task<List<Consultation>> Handle(GetConsultationsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var consultations = await context.Consultations
            .Include(x => x.Patient)
            .Where(x => x.Patient.Id == request.UserId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return consultations;
    }
}

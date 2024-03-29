using Domain.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetConsultations;

public class GetConsultationsHandler : IRequestHandler<GetConsultationsQuery, List<Consultation>>
{
    private readonly ApplicationDbContext context;

    public GetConsultationsHandler(ApplicationDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this.context = context;
    }

    public async Task<List<Consultation>> Handle(GetConsultationsQuery request, CancellationToken cancellationToken)
    {
        var consultations = await context.Consultations
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .Where(x => x.Patient.Id == request.UserId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return consultations;
    }
}

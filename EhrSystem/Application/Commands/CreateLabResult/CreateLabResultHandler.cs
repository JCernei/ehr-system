using Domain.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.WebEncoders.Testing;

namespace Application.Commands.CreateLabResult;

public class CreateLabResultHandler : IRequestHandler<CreateLabResultCommand, CommandStatus>
{
    private readonly ApplicationDbContext dbContext;
    private readonly string fileStoragePath;

    public CreateLabResultHandler(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
        fileStoragePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles"); // Change this path as needed
    }

    public async Task<CommandStatus> Handle(CreateLabResultCommand request, CancellationToken cancellationToken)
    {
        var labResult = new LabResult
        {
            PatientId = request.PatientId,
            LabTechnicianId = request.LabTechnicianId,
            TestName = request.TestName,
            FilePath = "",
        };

        // Access files from the request directly
        var files = request.Files;

        // Create the directory if it doesn't exist
        Directory.CreateDirectory(fileStoragePath);

        // Handle file upload logic here
        foreach (var file in files)
        {
            if (file.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream, cancellationToken);
                }

                // Update labResult with the file path or any other relevant information
                labResult.FilePath = filePath;
            }
        }

        dbContext.LabResults.Add(labResult);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CommandStatus();
    }
}
using Domain.Models;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.CreateLabResult;

public class CreateLabResultHandler : IRequestHandler<CreateLabResultCommand, CommandStatus>
{
    private readonly ApplicationDbContext dbContext;
    private readonly string fileStoragePath;

    public CreateLabResultHandler(ApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        this.dbContext = dbContext;
        fileStoragePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "UploadedFiles");
    }

    public async Task<CommandStatus> Handle(CreateLabResultCommand request, CancellationToken cancellationToken)
    {
        var labResult = new LabResult
        {
            PatientId = request.PatientId,
            LabTechnicianId = request.LabTechnicianId,
            TestName = request.TestName,
            FilePaths = new List<string>()
        };

        // Ensure both Files and FileNames have the same number of elements
        if (request.Files.Count() != request.FileNames.Count())
            throw new ArgumentException("Number of files and filenames must match");

        // Create the directory if it doesn't exist
        Directory.CreateDirectory(fileStoragePath);

        // Combine file streams with their corresponding names
        var fileInfoList = request.Files.Zip(request.FileNames, (file, fileName) => new
        {
            Stream = file,
            FileName = fileName
        });

        foreach (var fileInfo in fileInfoList)
        {
            if (fileInfo.Stream.Length > 0)
            {
                var filePath = Path.Combine(fileStoragePath, Guid.NewGuid() + Path.GetExtension(fileInfo.FileName));

                using (var stream = new FileStream(filePath, FileMode.Create))
                    await fileInfo.Stream.CopyToAsync(stream, cancellationToken);

                // You can store the filename along with the path or use it for further processing
                labResult.FilePaths.Add(filePath);
            }
        }

        dbContext.LabResults.Add(labResult);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CommandStatus();
    }
}

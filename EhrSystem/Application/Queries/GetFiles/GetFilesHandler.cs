using System.Reflection.Metadata.Ecma335;
using MediatR;

namespace Application.Queries.GetFiles;

public class GetFilesHandler : IRequestHandler<GetFilesQuery, List<Stream>>
{
    
    public async Task<List<Stream>> Handle(GetFilesQuery request, CancellationToken cancellationToken)
    {
        var files = new List<Stream>();
        if (request.FilePaths?.Any() == true)
        {
            foreach (var filePath in request.FilePaths)
            {
                if (System.IO.File.Exists(filePath))
                {
                    try
                    {
                        // Open the file stream for reading with appropriate access mode
                        files.Add(System.IO.File.OpenRead(filePath));
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (e.g., file access denied)
                        Console.WriteLine($"Error opening file {filePath}: {ex.Message}");
                    }
                }
                else
                {
                    // Handle non-existent files (log or throw exception)
                    Console.WriteLine($"File not found: {filePath}");
                }
            }
        }

        return files;
    }
}
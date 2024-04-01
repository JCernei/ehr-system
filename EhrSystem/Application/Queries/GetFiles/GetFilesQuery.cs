using MediatR;

namespace Application.Queries.GetFiles;

public class GetFilesQuery : IRequest<List<Stream>>
{
    public List<string> FilePaths { get; set; }
}

namespace Application.Commands;

public class CommandStatus
{
    public bool IsSuccessful { get; set; } = true;
    public string Error { get; set; } = string.Empty;

    public static CommandStatus Failed(string error)
    {
        return new CommandStatus
        {
            IsSuccessful = false,
            Error = error
        };
    }
}

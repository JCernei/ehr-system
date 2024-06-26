namespace Shared;

public class UserDto
{
    public string Id { get; set; }
    public string Idnp { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}

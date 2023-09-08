using SaveKids.Domain.Enums;
using SaveKids.Domain.Commons;

namespace SaveKids.Domain.Entities.Users;

public class User : Person
{
    public string TelNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}

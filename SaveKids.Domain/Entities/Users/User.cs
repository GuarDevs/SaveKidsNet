using SaveKids.Domain.Commons;
using SaveKids.Domain.Enums;

namespace SaveKids.Domain.Entities.Users;

public class User : Person
{
    public string TelNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}

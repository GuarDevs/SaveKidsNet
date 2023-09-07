namespace SaveKids.Domain.Commons;

public abstract class Person : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}
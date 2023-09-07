namespace SaveKids.Domain.Entities;

public class Auditable
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}

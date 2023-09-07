using SaveKids.Domain.Commons;
using SaveKids.Domain.Entities.Attachments;

namespace SaveKids.Domain.Entities.Criminals;

public class Criminal : Person
{
    public string PlaceOfBirth { get; set; }
    public string Nationatily { get; set; }
    public string Hair { get; set; }
    public string Eyes { get; set; }
    public string Gender { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public string Detail { get; set; }
    public long? AttachmendId { get; set; }
    public Attachment Attachment { get; set; }
}

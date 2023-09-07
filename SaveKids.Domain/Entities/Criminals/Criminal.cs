using SaveKids.Domain.Commons;
using SaveKids.Domain.Entities.Attachments;
using SaveKids.Domain.Entities.Crimes;

namespace SaveKids.Domain.Entities.Criminals;

public class Criminal : Person
{
    public string PlaceOfBirth { get; set; } = string.Empty;
    public string Nationatily { get; set; } = string.Empty;
    public string Hair { get; set; } = string.Empty;
    public string Eyes { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public double Height { get; set; }
    public double Weight { get; set; }

    public string Detail { get; set; } = string.Empty;
    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; } = default!;
    public ICollection<Crime> Crimes { get; set; }

}

using SaveKids.Domain.Commons;

namespace SaveKids.Domain.Entities.Attachments;

public class Attachment : Auditable
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
}

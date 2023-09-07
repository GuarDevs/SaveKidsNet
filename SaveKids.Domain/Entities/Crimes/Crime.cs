using SaveKids.Domain.Commons;
using SaveKids.Domain.Entities.Attachments;
using SaveKids.Domain.Entities.Criminals;
using System.Reflection.Metadata.Ecma335;

namespace SaveKids.Domain.Entities.Crimes;

public class Crime : Auditable
{
    public string PlaceOfCrime { get; set; }
    public DateTime DateOfCrime { get; set; }
    public string Description { get; set; }
    public string Detail { get; set; }
    public long CriminalId { get; set; }
    public Criminal Criminal { get; set; }
    public long CriminalCategoryId { get; set; }
    public CrimeCategory CriminalCategory { get; set; }
}

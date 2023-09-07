using SaveKids.Domain.Commons;
using SaveKids.Domain.Entities.Criminals;

namespace SaveKids.Domain.Entities.Crimes;

public class Crime : Auditable
{
    public string PlaceOfCrime { get; set; }
    public DateTime DateOfCrime { get; set; }
    public string Description { get; set; }
    public string Detail { get; set; }
    public long CriminalId { get; set; }
    public Criminal Criminal { get; set; }
    public long CrimeCategoryId { get; set; }
    public CrimeCategory CrimeCategory { get; set; }
}

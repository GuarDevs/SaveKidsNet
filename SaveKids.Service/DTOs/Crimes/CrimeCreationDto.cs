using SaveKids.Domain.Entities.Crimes;
using SaveKids.Domain.Entities.Criminals;

namespace SaveKids.Service.DTOs.Crimes;

public class CrimeCreationDto
{
    public string PlaceOfCrime { get; set; }
    public DateTime DateOfCrime { get; set; }
    public string Description { get; set; }
    public string Detail { get; set; }
    public long CriminalId { get; set; }
    public long CriminalCategoryId { get; set; }
}

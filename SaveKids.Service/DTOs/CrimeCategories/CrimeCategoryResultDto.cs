using SaveKids.Service.DTOs.Crimes;

namespace SaveKids.Service.DTOs.CrimeCategories;

public class CrimeCategoryResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<CrimeResultDto> Crimes { get; set; }
}
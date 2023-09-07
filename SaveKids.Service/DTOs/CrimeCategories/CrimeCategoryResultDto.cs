using SaveKids.Domain.Entities.Crimes;

namespace SaveKids.Service.DTOs.CrimeCategories;

public class CrimeCategoryResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<Crime> Crimes { get; set; }
}
using SaveKids.Service.DTOs.CrimeCategories;
using SaveKids.Service.DTOs.Criminals;

namespace SaveKids.Service.DTOs.Crimes;

public class CrimeResultDto
{
    public long Id { get; set; }
    public string PlaceOfCrime { get; set; }
    public DateTime DateOfCrime { get; set; }
    public string Description { get; set; }
    public string Detail { get; set; }
    public  CriminalResultDto Criminal { get; set; }
    public CrimeCategoryResultDto CrimeCategory { get; set; }
}
namespace SaveKids.Service.DTOs.Crimes;

public class CrimeUpdateDto
{
    public long Id { get; set; }
    public string PlaceOfCrime { get; set; }
    public DateTime DateOfCrime { get; set; }
    public string Description { get; set; }
    public string Detail { get; set; }
    public long CriminalId { get; set; }
    public long CriminalCategoryId { get; set; }
}

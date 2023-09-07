using SaveKids.Domain.Entities.Attachments;
using SaveKids.Service.DTOs.Crimes;

namespace SaveKids.Service.DTOs.Criminals;

public class CriminalResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PlaceOfBirth { get; set; }
    public string Nationatily { get; set; }
    public string Hair { get; set; }
    public string Eyes { get; set; }
    public string Gender { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public string Detail { get; set; }
    public Attachment Attachment { get; set; }
    public ICollection<CrimeResultDto> Crimes { get; set; }
}
using SaveKids.Domain.Entities.Attachments;
using SaveKids.Service.DTOs.Crimes;
using System.ComponentModel;

namespace SaveKids.Service.DTOs.Criminals;

public class CriminalResultDto
{
    [DisplayName("Id")]
    public long Id { get; set; }
    
    [DisplayName("First name")]
    public string FirstName { get; set; }
    
    [DisplayName("Last name")]
    public string LastName { get; set; }
    
    [DisplayName("Date of birth")]
    public DateTime DateOfBirth { get; set; }
    
    [DisplayName("Place of birth")]
    public string PlaceOfBirth { get; set; }
    
    [DisplayName("Nationality")]
    public string Nationatily { get; set; }
    
    [DisplayName("Hair color")]
    public string Hair { get; set; }
    
    [DisplayName("Eye color")]
    public string Eyes { get; set; }
    
    [DisplayName("Gender")]
    public string Gender { get; set; }
    
    [DisplayName("Height")]
    public double Height { get; set; }
    
    [DisplayName("Weight")]
    public double Weight { get; set; }
    
    [DisplayName("Details")]
    public string Detail { get; set; }
    
    [DisplayName("Attachment")]
    public Attachment Attachment { get; set; }
    
    [DisplayName("Crimes")]
    public ICollection<CrimeResultDto> Crimes { get; set; }
}
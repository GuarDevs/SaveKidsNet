using SaveKids.Domain.Commons;

namespace SaveKids.Domain.Entities.Crimes;

public class CrimeCategory : Auditable
{
    public string Name { get; set; }
    public ICollection<Crime> Crimes { get; set; }
}
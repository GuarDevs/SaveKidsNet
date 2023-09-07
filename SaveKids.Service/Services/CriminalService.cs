using SaveKids.Domain.Configurations;
using SaveKids.Service.DTOs.Crimes;
using SaveKids.Service.Interfaces;

namespace SaveKids.Service.Services;

public class CriminalService : ICrimeService
{
    public Task<CrimeResultDto> AddAsync(CrimeCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DestroyAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<CrimeResultDto> ModifyAsync(CrimeUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CrimeResultDto>> RetrieveAllAsync(PaginationParams pagination)
    {
        throw new NotImplementedException();
    }

    public Task<CrimeResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}

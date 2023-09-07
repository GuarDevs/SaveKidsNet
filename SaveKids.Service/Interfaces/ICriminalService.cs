using SaveKids.Service.DTOs.Criminals;
using SaveKids.Service.DTOs.Users;

namespace SaveKids.Service.Interfaces;

public interface ICriminalService
{
    Task<CriminalResultDto> AddAsync(CriminalCreationDto dto);
    Task<CriminalResultDto> ModifyAsync(CriminalUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<bool> DestroyAsync(long id);
    Task<UserResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<UserResultDto>> RetrieveAllAsync();
}
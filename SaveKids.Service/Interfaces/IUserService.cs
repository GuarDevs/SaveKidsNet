using SaveKids.Domain.Configurations;
using SaveKids.Service.DTOs.Users;

namespace SaveKids.Service.Interfaces;

public interface IUserService
{
    Task<UserResultDto> AddAsync(UserCreationDto dto);
    Task<UserResultDto> ModifyAsync(UserUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<UserResultDto> RetrieveByIdAsync(long id);
    Task<UserResultDto> RetrieveByEmailAndPasswordAsync(string email, string password);
    Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams paginationParams);
}

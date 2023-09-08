using SaveKids.Domain.Configurations;
using SaveKids.Domain.Enums;
using SaveKids.Service.DTOs.Users;

namespace SaveKids.Service.Interfaces;

public interface IUserService
{
    Task<UserResultDto> AddAsync(UserCreationDto dto);
    Task<UserResultDto> ModifyAsync(UserUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<bool> DestroyAsync(long id);
    Task<UserResultDto> RetrieveByIdAsync(long id);
    Task<UserResultDto> RetrieveByEmailAndPasswordAsync(string email, string password);
    Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams paginationParams);
    Task<UserResultDto> UpgradeUserRoleAsync(long userId, UserRole role);
    Task<IEnumerable<UserResultDto>> SearchByNameAsync(string name, PaginationParams paginationParams);
}

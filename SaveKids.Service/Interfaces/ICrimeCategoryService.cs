using SaveKids.Domain.Configurations;
using SaveKids.Service.DTOs.CrimeCategories;

namespace SaveKids.Service.Interfaces;

public interface ICrimeCategoryService
{
    Task<CrimeCategoryResultDto> AddAsync(CrimeCategoryCreationDto dto);
    Task<CrimeCategoryResultDto> ModifyAsync(CrimeCategoryUpdateDto dto);
    Task<bool> DestroyAsync(long id);
    Task<CrimeCategoryResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<CrimeCategoryResultDto>> RetrieveAllAsync(PaginationParams pagination);
}
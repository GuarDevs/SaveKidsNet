using SaveKids.Domain.Configurations;
using SaveKids.Service.DTOs.Attachments;
using SaveKids.Service.DTOs.Criminals;

namespace SaveKids.Service.Interfaces;

public interface ICriminalService
{
    Task<CriminalResultDto> AddAsync(CriminalCreationDto dto);
    Task<CriminalResultDto> ModifyAsync(CriminalUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<bool> DestroyAsync(long id);
    Task<CriminalResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<CriminalResultDto>> RetrieveAllAsync(PaginationParams pagination);
    Task<CriminalResultDto> ModifyImageAsync(long criminalId, AttachmentCreationDto dto);
    Task<CriminalResultDto> UploadImageAsync(long criminalId, AttachmentCreationDto dto);
}
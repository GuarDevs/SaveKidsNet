using SaveKids.Domain.Entities.Attachments;
using SaveKids.Service.DTOs.Attachments;

namespace SaveKids.Service.Interfaces;

public interface IAttachmentService
{
    Task<Attachment> UploadAsync(AttachmentCreationDto dto);
    Task<bool> RemoveAsync(Attachment attachment);
}
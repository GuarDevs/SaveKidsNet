using SaveKids.Domain.Entities.Attachments;
using SaveKids.Service.DTOs.Attachments;
using SaveKids.Service.Interfaces;

namespace SaveKids.Service.Services;

public class AttachmentService : IAttachmentService
{
    private readonly IAttachmentService attachmentService;

    public AttachmentService(IAttachmentService attachmentService)
    {
        this.attachmentService = attachmentService;
    }

    public Task<Attachment> UploadAsync(AttachmentCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(Attachment attachment)
    {
        throw new NotImplementedException();
    }

}

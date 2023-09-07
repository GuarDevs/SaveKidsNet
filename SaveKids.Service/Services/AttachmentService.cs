using SaveKids.DAL.IRepositories;
using SaveKids.Service.DTOs.Attachments;
using SaveKids.Service.Extensions;
using SaveKids.Service.Helpers;
using SaveKids.Service.Interfaces;
using SaveKids.Domain.Entities.Attachments;

namespace SaveKids.Service.Services;

public class AttachmentService : IAttachmentService
{
    private readonly IRepository<Attachment> repository;

    public AttachmentService(IRepository<Attachment> repository)
    {
        this.repository = repository;
    }

    public async Task<Attachment> UploadAsync(AttachmentCreationDto dto)
    {
        var webRootPath = Path.Combine(PathHelper.WebRootPath, "Images");

        if (!Directory.Exists(webRootPath))
            Directory.CreateDirectory(webRootPath);

        var fileExtention = Path.GetExtension(dto.FormFile.FileName);
        var fileName = $"{Guid.NewGuid().ToString("N")}{fileExtention}";
        var filePath = Path.Combine(webRootPath, fileName);

        var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(dto.FormFile.ToByte());

        var attachment = new Attachment()
        {
            FileName = fileName,
            FilePath = filePath,
        };

        await repository.AddAsync(attachment);
        await repository.SaveAsync();

        return attachment;
    }

    public async Task<bool> RemoveAsync(Attachment attachment)
    {
        if (attachment is null)
            return false;

        var existAttachment = await repository.GetAsync(a => a.Id.Equals(attachment.Id));

        if (existAttachment is null)
            return false;

        repository.Delete(attachment);
        await repository.SaveAsync();

        return true;
    }
}

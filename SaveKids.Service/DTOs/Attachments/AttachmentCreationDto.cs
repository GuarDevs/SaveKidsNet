using Microsoft.AspNetCore.Http;

namespace SaveKids.Service.DTOs.Attachments;

public class AttachmentCreationDto
{
    public IFormFile FormFile { get; set; }
}

using Microsoft.AspNetCore.Mvc;
using SaveKids.Domain.Configurations;
using SaveKids.Service.DTOs.Attachments;
using SaveKids.Service.DTOs.Criminals;
using SaveKids.Service.Interfaces;
using SaveKids.Service.Services;

namespace SaveKids.WebApi.Controllers;

public class CriminalsController : BaseController
{
    private readonly ICriminalService _criminalService;

    public CriminalsController(ICriminalService criminalService)
    {
        _criminalService = criminalService;
    }


    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync(CriminalCreationDto dto)
    => Ok(await _criminalService.AddAsync(dto));


    [HttpPost("upload-image")]
    public async ValueTask<IActionResult> ImageUploadAsync(long criminalId, [FromForm] AttachmentCreationDto dto)
    {
        var result = await _criminalService.UploadImageAsync(criminalId, dto);
        return Ok(result);
    }

    [HttpPost("update-image")]
    public async ValueTask<IActionResult> ModifyImageAsync(long criminalId, [FromForm] AttachmentCreationDto dto)
    {
        var result = await _criminalService.ModifyImageAsync(criminalId, dto);
        return Ok(result);
    }


    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAsync(CriminalUpdateDto dto)
        => Ok(await _criminalService.ModifyAsync(dto));


    [HttpPatch("Delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(await _criminalService.RemoveAsync(id));


    [HttpDelete("Destroy/{id:long}")]
    public async Task<IActionResult> DestroyAsync(long id)
        => Ok(await _criminalService.DestroyAsync(id));


    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(await _criminalService.RetrieveByIdAsync(id));


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams paginationParams)
        => Ok(await _criminalService.RetrieveAllAsync(paginationParams));
}

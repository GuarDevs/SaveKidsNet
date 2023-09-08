using Microsoft.AspNetCore.Mvc;
using SaveKids.Domain.Configurations;
using SaveKids.Service.DTOs.CrimeCategories;
using SaveKids.Service.Interfaces;

namespace SaveKids.WebApi.Controllers;

public class CrimeCategoriesController : BaseController
{
    private readonly ICrimeCategoryService _crimeCategoryService;

    public CrimeCategoriesController(ICrimeCategoryService crimeCategoryService)
    {
        _crimeCategoryService = crimeCategoryService;
    }


    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync(CrimeCategoryCreationDto dto)
        => Ok(await _crimeCategoryService.AddAsync(dto));


    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAsync(CrimeCategoryUpdateDto dto)
        => Ok(await _crimeCategoryService.ModifyAsync(dto));


    [HttpDelete("Destroy/{id:long}")]
    public async Task<IActionResult> DestroyAsync(long id)
        => Ok(await _crimeCategoryService.DestroyAsync(id));


    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(await _crimeCategoryService.RetrieveByIdAsync(id));


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _crimeCategoryService.RetrieveAllAsync());
}

using Microsoft.AspNetCore.Mvc;
using SaveKids.Domain.Configurations;
using SaveKids.Service.DTOs.Crimes;
using SaveKids.Service.Interfaces;
using SaveKids.Service.Services;

namespace SaveKids.WebApi.Controllers;

public class CrimesController : BaseController
{
    private readonly ICrimeService _crimeService;

    public CrimesController(ICrimeService crimeService)
    {
        _crimeService = crimeService;
    }


    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync(CrimeCreationDto dto)
        => Ok(await _crimeService.AddAsync(dto));


    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAsync(CrimeUpdateDto dto)
        => Ok(await _crimeService.ModifyAsync(dto));


    [HttpPatch("Delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(await _crimeService.RemoveAsync(id));


    [HttpDelete("Destroy/{id:long}")]
    public async Task<IActionResult> DestroyAsync(long id)
        => Ok(await _crimeService.DestroyAsync(id));


    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(await _crimeService.RetrieveByIdAsync(id));


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams paginationParams)
        => Ok(await _crimeService.RetrieveAllAsync(paginationParams));


    [HttpGet("SearchByDescription")]
    public async Task<IActionResult> SearchByNameAsync(string description, [FromQuery] PaginationParams paginationParams)
    => Ok(await _crimeService.SearchByDescriptionAsync(description, paginationParams));
}

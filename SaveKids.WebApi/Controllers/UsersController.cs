using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaveKids.Domain.Configurations;
using SaveKids.Service.DTOs.Users;
using SaveKids.Service.Interfaces;

namespace SaveKids.WebApi.Controllers;

public class UsersController : BaseController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync(UserCreationDto dto)
        => Ok(await _userService.AddAsync(dto));


    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAsync(UserUpdateDto dto)
        => Ok(await _userService.ModifyAsync(dto));


    [HttpPatch("Delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(await _userService.RemoveAsync(id));


    [HttpDelete("Destroy/{id:long}")]
    public async Task<IActionResult> DestroyAsync(long id)
        => Ok(await _userService.DestroyAsync(id));


    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(await _userService.RetrieveByIdAsync(id));


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams paginationParams)
        => Ok(await _userService.RetrieveAllAsync(paginationParams));


    [HttpGet("GetByEmailAndPassword")]
    public async Task<IActionResult> GetByEmailAndPassword(string email, string password)
        => Ok(await _userService.RetrieveByEmailAndPasswordAsync(email, password));
}

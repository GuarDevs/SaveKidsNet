using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaveKids.Domain.Configurations;
using SaveKids.Domain.Enums;
using SaveKids.Service.DTOs.Users;
using SaveKids.Service.Interfaces;
using System.Security.Claims;

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


    [Authorize(Roles = "SuperAdmin,Admin")]
    [HttpDelete("Delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(await _userService.RemoveAsync(id));


    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUserAsync()
    {
        var id = Convert.ToInt32(HttpContext.User.FindFirstValue("Id"));

        var result = await _userService.RemoveAsync(id);

        return Ok(result);
    }


    [Authorize(Roles = "SuperAdmin")]
    [HttpDelete("Destroy/{id:long}")]
    public async Task<IActionResult> DestroyAsync(long id)
        => Ok(await _userService.DestroyAsync(id));


    [Authorize(Roles = "SuperAdmin,Admin")]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(await _userService.RetrieveByIdAsync(id));


    [HttpGet("GetByUserId")]
    public async Task<IActionResult> GetByUserIdAsync()
    {
        var id = Convert.ToInt32(HttpContext.User.FindFirstValue("Id"));

        var result = await _userService.RetrieveByIdAsync(id);

        return Ok(result);
    }

    [Authorize(Roles = "SuperAdmin,Admin")]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams paginationParams)
        => Ok(await _userService.RetrieveAllAsync(paginationParams));


    [Authorize(Roles = "SuperAdmin,Admin")]
    [HttpGet("SearchByName")]
    public async Task<IActionResult> SearchByNameAsync(string name,[FromQuery] PaginationParams paginationParams)
    => Ok(await _userService.SearchByNameAsync(name,paginationParams));


    [HttpGet("GetByEmailAndPassword")]
    public async Task<IActionResult> GetByEmailAndPassword(string email, string password)
        => Ok(await _userService.RetrieveByEmailAndPasswordAsync(email, password));

    [Authorize(Roles = "SuperAdmin")]
    [HttpPatch("update-role")]
    public async Task<IActionResult> UpdateUserRoleAsync(long id, UserRole role)
        => Ok(await _userService.UpgradeUserRoleAsync(id,role));

}

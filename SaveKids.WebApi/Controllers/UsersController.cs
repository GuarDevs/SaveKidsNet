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

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams)
        => Ok(await _userService.RetrieveAllAsync(paginationParams));

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromForm] UserCreationDto dto)
        => Ok(await _userService.AddAsync(dto));


    //// GET: UsersController/Edit/5
    //public ActionResult Edit(int id)
    //{
    //    return View();
    //}

    //// POST: UsersController/Edit/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Edit(int id, IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: UsersController/Delete/5
    //public ActionResult Delete(int id)
    //{
    //    return View();
    //}

    //// POST: UsersController/Delete/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Delete(int id, IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}
}

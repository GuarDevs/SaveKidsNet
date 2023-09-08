using Microsoft.AspNetCore.Mvc;
using SaveKids.Service.DTOs.Users;
using SaveKids.Service.Interfaces;
using SaveKidsNet.Wep.Models;

namespace SaveKidsNet.Wep.Controllers;

public class UsersController : Controller
{
    private readonly IUserService userService;
    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginModel model)
    {
        var user = await this.userService.RetrieveByEmailAndPasswordAsync(model.Email, model.Password);
        return RedirectToAction("Index");
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserCreationDto dto)
    {
        var result = await this.userService.AddAsync(dto);
        return RedirectToAction("Index");
    }
}
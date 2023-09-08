using Microsoft.AspNetCore.Mvc;
using SaveKids.Service.DTOs.Users;
using SaveKids.Service.Interfaces;

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
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await this.userService.RetrieveByEmailAndPasswordAsync(email, password);
        if (user is null)
            return NotFound();

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
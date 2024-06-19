using Microsoft.AspNetCore.Mvc;
using PersonelApp.WebAPI.DTOs;
using PersonelApp.WebAPI.Models;
using PersonelApp.WebAPI.Services;

namespace PersonelApp.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class AuthController(
    IUserService userService,
    IAuthTokenService authTokenService) : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromForm] RegisterDto request)
    {
        var result = userService.Register(request);
        if (!result)
        {
            return BadRequest(new { Message = "Something went wrong" });
        }

        return Ok(new { Message = "Registration is successful" });
    }

    [HttpPost]
    public IActionResult Login(LoginDto request)
    {
        User? user = userService.Login(request);
        if (user is null)
        {
            return BadRequest(new { Message = "User name or password is wrong" });
        }

        var response = authTokenService.Create(user);

        return Ok(response);
    }
}

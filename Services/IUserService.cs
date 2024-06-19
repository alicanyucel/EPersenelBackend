using PersonelApp.WebAPI.DTOs;
using PersonelApp.WebAPI.Models;

namespace PersonelApp.WebAPI.Services;

public interface IUserService
{
    bool Register(RegisterDto request);
    User? Login(LoginDto request);
}

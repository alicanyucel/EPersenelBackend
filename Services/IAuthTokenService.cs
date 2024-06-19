using ePersonelServer.WebAPI.DTOs;
using PersonelApp.WebAPI.Models;

namespace PersonelApp.WebAPI.Services;

public interface IAuthTokenService
{
    LoginResponseDto Create(User user, bool rememberMe = false);
    bool CheckSecretKey(string secretKey);
}
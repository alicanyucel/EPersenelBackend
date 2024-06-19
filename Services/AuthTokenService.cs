using ePersonelServer.WebAPI.DTOs;
using PersonelApp.WebAPI.Models;
using PersonelApp.WebAPI.Repositories;
using System.Text;

namespace PersonelApp.WebAPI.Services;

public sealed class AuthTokenService(
    IAuthTokenRepository authTokenRepository) : IAuthTokenService
{
    public bool CheckSecretKey(string secretKey)
    {
        AuthToken? authToken = authTokenRepository.CheckSecretkeyIsAvailable(secretKey);

        if (authToken is null || authToken.ExpireDate < DateTime.Now)
        {
            return false;
        }

        return true;
    }

    public LoginResponseDto Create(User user, bool rememberMe = false)
    {
        byte[] secretKey;

        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            long time = DateTime.Now.ToFileTime();
            secretKey =
                hmac
                .ComputeHash(
                    Encoding.UTF8.GetBytes(time.ToString() + "My secret key" + user.Id.ToString()));
        }

        DateTime expires = DateTime.Now.AddDays(1);
        if (rememberMe)
        {
            expires = DateTime.Now.AddMonths(1);
        }

        AuthToken authToken = new()
        {
            UserId = user.Id,
            CreateDate = DateTime.Now,
            ExpireDate = expires,
            SecretKey = Convert.ToBase64String(secretKey)
        };

        var result = authTokenRepository.Create(authToken);
        if (result)
        {
            string fullName = string.Join(" ", user.FirstName, user.LastName);
            return new LoginResponseDto(
                authToken.SecretKey,
                fullName,
                user.AvatarUrl,
                authToken.ExpireDate);
        }

        throw new ArgumentException("Something went wrong");
    }
}

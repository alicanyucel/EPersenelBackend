using PersonelApp.WebAPI.Context;
using PersonelApp.WebAPI.Models;

namespace PersonelApp.WebAPI.Repositories;

public sealed class AuthTokenRepository(
    ApplicationDbContext context) : IAuthTokenRepository
{
    public AuthToken? CheckSecretkeyIsAvailable(string secretKey)
    {
        return context.AuthTokens.FirstOrDefault(p => p.SecretKey == secretKey);
    }

    public bool Create(AuthToken authToken)
    {
        context.Add(authToken);
        int result = context.SaveChanges();

        return result > 0;
    }
}

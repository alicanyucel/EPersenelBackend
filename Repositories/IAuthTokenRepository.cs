using PersonelApp.WebAPI.Models;

namespace PersonelApp.WebAPI.Repositories;

public interface IAuthTokenRepository
{
    bool Create(AuthToken authToken);
    AuthToken? CheckSecretkeyIsAvailable(string secretKey);
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using PersonelApp.WebAPI.Services;

namespace PersonelApp.WebAPI.Filters;

public sealed class MyAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var scoped = context.HttpContext.RequestServices.CreateScope();
        IAuthTokenService authTokenService = scoped.ServiceProvider.GetRequiredService<IAuthTokenService>();

        KeyValuePair<string, StringValues> secretKeyHeader =
            context.HttpContext.Request.Headers.FirstOrDefault(p => p.Key == "secretkey");

        if (secretKeyHeader.Key is null || !authTokenService.CheckSecretKey(secretKeyHeader.Value.ToString()))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
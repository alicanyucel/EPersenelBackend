using Microsoft.AspNetCore.Diagnostics;

namespace PersonelApp.WebAPI.Filters;

public sealed class MyExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync(exception.Message);
        return true;
    }
}

//public sealed class MyExceptionMiddleware : IMiddleware
//{
//    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
//    {
//        try
//        {
//            await next(context);
//        }
//        catch (Exception exception)
//        {
//            context.Response.ContentType = "application/json";
//            context.Response.StatusCode = 500;
//            await context.Response.WriteAsync(exception.Message); ;
//        }
//    }
//}

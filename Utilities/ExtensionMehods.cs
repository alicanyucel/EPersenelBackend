using PersonelApp.WebAPI.Context;
using PersonelApp.WebAPI.Filters;
using PersonelApp.WebAPI.Repositories;
using PersonelApp.WebAPI.Services;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace PersonelApp.WebAPI.Utilities;

public static class ExtensionMehods
{
    public static string ToErrorResult(this string value)
    {
        return ErrorResult.Failure(value);
    }

    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddTransient<ApplicationDbContext>();
        services.AddTransient<IPersonelRepository, PersonelRepository>();
        services.AddTransient<IPersonelService, PersonelService>();

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserService, UserService>();

        services.AddTransient<IAuthTokenRepository, AuthTokenRepository>();
        services.AddTransient<IAuthTokenService, AuthTokenService>();
        return services;
    }

    public static IServiceCollection AddUI(this IServiceCollection services)
    {
        services.AddCors();

        services.AddControllers();

        services.AddMemoryCache();

        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();

        services.AddAutoMapper(typeof(Program).Assembly);

        services.AddExceptionHandler<MyExceptionHandler>().AddProblemDetails();

        return services;
    }

    public static IHostBuilder AddLog(this IHostBuilder host, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
        .WriteTo.Console(LogEventLevel.Information)
        .WriteTo.File("./log.txt", LogEventLevel.Information, rollingInterval: RollingInterval.Month)
        .WriteTo.MSSqlServer(
        connectionString: configuration.GetConnectionString("SqlServer"),
        sinkOptions: new MSSqlServerSinkOptions()
        {
            TableName = "Logs",
            AutoCreateSqlTable = true
        })
        .CreateLogger();

        host.UseSerilog();

        return host;
    }
}
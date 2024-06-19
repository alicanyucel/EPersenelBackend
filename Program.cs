using PersonelApp.WebAPI.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddUI();

builder.Services.AddDependencyInjection();

builder.Host.AddLog(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.UseExceptionHandler();

app.Run();

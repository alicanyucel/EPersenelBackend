namespace PersonelApp.WebAPI.DTOs;

public sealed record LoginDto(
    string UserName,
    string Password,
    bool RememberMe);

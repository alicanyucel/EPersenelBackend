namespace PersonelApp.WebAPI.DTOs;

public sealed record RegisterDto(
    string FirstName,
    string LastName,
    string UserName,
    string Password,
    IFormFile File);

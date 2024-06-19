namespace PersonelApp.WebAPI.DTOs;

public sealed record CreatePersonelDto(
    string FirstName,
    string LastName,
    DateOnly StartingDate);

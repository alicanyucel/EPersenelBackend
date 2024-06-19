namespace ePersonelServer.WebAPI.DTOs;

public sealed record LoginResponseDto(
    string SecretKey,
    string FullName,
    string AvatarUrl,
    DateTime Expires);

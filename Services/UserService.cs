using AutoMapper;
using PersonelApp.WebAPI.DTOs;
using PersonelApp.WebAPI.Models;
using PersonelApp.WebAPI.Repositories;
using PersonelApp.WebAPI.Utilities;

namespace PersonelApp.WebAPI.Services;

public sealed class UserService(
    IUserRepository userRepository,
    IMapper mapper) : IUserService
{
    public User? Login(LoginDto request)
    {
        if (request.UserName.Length < 3)
        {
            string errorMessage = "User name must be greater than 3 characters";
            throw new ArgumentException(errorMessage.ToErrorResult());

        }

        return userRepository.GetByUserNameAndPassword(request.UserName, request.Password);
    }

    public bool Register(RegisterDto request)
    {
        string fileName = string.Join("-", DateTime.Now.ToFileTime(), request.File.FileName);
        var stream = System.IO.File.Create($"wwwroot/avatars/{fileName}");
        request.File.CopyTo(stream);

        bool isUserNameExists = userRepository.IsUserNameExists(request.UserName);
        if (isUserNameExists)
        {
            string errorMessage = "User name already exists";
            throw new ArgumentException(errorMessage.ToErrorResult());
        }

        User user = mapper.Map<User>(request);
        user.AvatarUrl = fileName;

        return userRepository.Create(user);
    }
}

using PersonelApp.WebAPI.Context;
using PersonelApp.WebAPI.Models;

namespace PersonelApp.WebAPI.Repositories;

public sealed class UserRepository(
    ApplicationDbContext context) : IUserRepository
{
    public bool Create(User user)
    {
        context.Add(user);
        int result = context.SaveChanges();
        return result > 0;
    }

    public User? GetByUserNameAndPassword(string userName, string password)
    {
        return context.Users.FirstOrDefault(p => p.UserName == userName && p.Password == password);
    }

    public bool IsUserNameExists(string userName)
    {
        return context.Users.Any(x => x.UserName == userName);
    }
}

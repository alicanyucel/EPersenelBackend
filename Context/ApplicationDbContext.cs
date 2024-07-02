using Microsoft.EntityFrameworkCore;
using PersonelApp.WebAPI.Models;

namespace PersonelApp.WebAPI.Context;

public sealed class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseInMemoryDatabase("MyDb");
        optionsBuilder.UseSqlServer("Data Source=TANER\\SQLEXPRESS;Initial Catalog=ePersonelDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    public DbSet<Personel> Personels { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AuthToken> AuthTokens { get; set; }

}

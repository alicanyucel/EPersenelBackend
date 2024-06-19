using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PersonelApp.WebAPI.Context;
using PersonelApp.WebAPI.Models;

namespace PersonelApp.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class SeedDataController(
    ApplicationDbContext context,
    IMemoryCache memoryCache) : ControllerBase
{
    [HttpGet]
    public IActionResult SeedPersonelData()
    {
        //List<Personel> personels = new();

        for (int i = 0; i < 10000000; i++)
        {
            Faker faker = new();
            Personel personel = new()
            {
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                StartingDate = DateOnly.FromDateTime(faker.Person.DateOfBirth)
            };
            context.Add(personel);
            context.SaveChanges();
            //personels.Add(personel);
        }



        memoryCache.Remove("personels");

        return Created();
    }
}


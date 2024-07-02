using ePersonelServer.WebAPI.AOP;
using Microsoft.AspNetCore.Mvc;
using PersonelApp.WebAPI.DTOs;
using PersonelApp.WebAPI.Services;

namespace PersonelApp.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
//[MyAuthorize]
public sealed class PersonelsController(
    IPersonelService personelService,
    ILogger<PersonelsController> logger) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll(int pageNumber = 1, string search = "")
    {
        var personels = personelService.GetAll(pageNumber, search);
        return Ok(personels);
    }

    [HttpGet]
    [EnableQueryWithMetadata]
    public IActionResult GetAllOData()
    {
        var personels = personelService.GetAllQueryable();
        return Ok(personels);
    }

    [HttpPost]
    public IActionResult Create(CreatePersonelDto request)
    {
        var result = personelService.Create(request);
        if (!result) return BadRequest(new { Message = "Something went wrong" });
        return Ok(new { Message = "Personel create is successful" });
    }
}

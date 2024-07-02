using PersonelApp.WebAPI.DTOs;
using PersonelApp.WebAPI.Models;
using PersonelApp.WebAPI.Utilities;

namespace PersonelApp.WebAPI.Services;

public interface IPersonelService
{
    PaginationResult GetAll(int pageNumber, string search);
    IQueryable<Personel> GetAllQueryable();
    bool Create(CreatePersonelDto request);
}

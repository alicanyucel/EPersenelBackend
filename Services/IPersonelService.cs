using PersonelApp.WebAPI.DTOs;
using PersonelApp.WebAPI.Utilities;

namespace PersonelApp.WebAPI.Services;

public interface IPersonelService
{
    PaginationResult GetAll(int pageNumber, string search);
    bool Create(CreatePersonelDto request);
}

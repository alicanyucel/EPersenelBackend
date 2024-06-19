using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using PersonelApp.WebAPI.DTOs;
using PersonelApp.WebAPI.Models;
using PersonelApp.WebAPI.Repositories;
using PersonelApp.WebAPI.Utilities;

namespace PersonelApp.WebAPI.Services;

public sealed class PersonelService(
    IPersonelRepository personelRepository,
    IMemoryCache memoryCache,
    IMapper mapper) : IPersonelService
{
    public bool Create(CreatePersonelDto request)
    {
        bool isPersonelExists = personelRepository.IsPersonelExists(request.FirstName, request.LastName);

        if (isPersonelExists)
        {
            string errorMessage = "Personel already exists";
            throw new ArgumentException(errorMessage.ToErrorResult());
        }

        Personel personel = mapper.Map<Personel>(request);

        var result = personelRepository.Create(personel);

        memoryCache.Remove("personels");

        return result;
    }

    public PaginationResult GetAll(int pageNumber, string search)
    {
        IQueryable<Personel> personelQueries = personelRepository.GetAll()
            .Where(p =>
            p.FirstName.ToLower().Contains(search.ToLower()) ||
            p.LastName.ToLower().Contains(search.ToLower()));

        var personels = personelQueries
            .Skip(10 * (pageNumber - 1))
            .Take(10).ToList();

        decimal count = personelQueries.Count();
        decimal totalPage = count / 10;
        decimal totalPageCeiling = Math.Ceiling(totalPage);
        int totalPageCount = Convert.ToInt32(totalPageCeiling);


        PaginationResult result = new(personels, totalPageCount);

        //memoryCache.TryGetValue("personels", out List<Personel>? personels);
        //if (personels is null)
        //{
        //    personels = personelRepository.GetAll();
        //    memoryCache.Set("personels", personels);
        //}

        return result;
    }
}

using PersonelApp.WebAPI.Models;

namespace PersonelApp.WebAPI.Utilities;

public sealed record PaginationResult(
    List<Personel> Data,
    int TotalPageCount);

namespace PersonelApp.WebAPI.Models;

public sealed record Personel
{
    public Personel()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly StartingDate { get; set; }
}

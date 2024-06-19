namespace PersonelApp.WebAPI.Models;

public sealed class AuthToken
{
    public AuthToken()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string SecretKey { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; }
    public DateTime ExpireDate { get; set; }
}

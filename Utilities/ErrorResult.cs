using System.Text.Json;

namespace PersonelApp.WebAPI.Utilities;

public sealed record ErrorResult(string Message)
{
    public static string Failure(string message)
    {
        return new ErrorResult(message).ToString();
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

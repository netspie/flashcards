namespace Flashcards.WebApp.Shared;

public static class GuidExtensions
{
    public static string ToBase64(this Guid guid)
    {
        return Convert.ToBase64String(guid.ToByteArray())
            .TrimEnd('=')        // remove padding
            .Replace('+', '-')   // URL-safe
            .Replace('/', '_');  // URL-safe
    }

    public static Guid ToGuidFromBase64(this string base64)
    {
        // Restore padding
        base64 = base64.Replace('-', '+').Replace('_', '/');
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }

        byte[] bytes = Convert.FromBase64String(base64);
        return new Guid(bytes);
    }
}
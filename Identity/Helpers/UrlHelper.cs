namespace Identity.Helpers;

public static class UrlHelper {
    public static ICollection<string> GetAllowedUrls() {
        return Environment.GetEnvironmentVariable("AllowedUrls")?.Split(",") ?? [];
    }
}
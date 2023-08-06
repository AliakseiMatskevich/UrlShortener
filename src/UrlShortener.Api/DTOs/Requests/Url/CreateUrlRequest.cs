namespace UrlShortener.Api.DTOs.Requests.Url
{
    public class CreateUrlRequest
    {
        public string? OriginalUrl { get; set; }
        public string? Host { get; set; }
        public Guid UserId { get; set; }
    }
}

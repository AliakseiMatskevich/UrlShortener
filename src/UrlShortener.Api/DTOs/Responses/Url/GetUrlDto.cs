namespace UrlShortener.Api.DTOs.Responses.Url
{
    public class GetUrlDto
    {
        public Guid Id { get; set; }
        public string? OriginalUrl { get; set; }
        public string? ShortUrl { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

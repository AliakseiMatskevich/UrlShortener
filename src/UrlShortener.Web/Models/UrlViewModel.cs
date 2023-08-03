namespace UrlShortener.Web.Models
{
    public class UrlViewModel
    {
        public Guid Id { get; set; }
        public string? OriginalUrl { get; set; }
        public string? ShortUrl { get; set; }
    }
}

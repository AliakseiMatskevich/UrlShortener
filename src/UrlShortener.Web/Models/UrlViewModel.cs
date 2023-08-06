using UrlShortener.ApplicationCore.Attributes.Validation;

namespace UrlShortener.Web.Models
{
    public class UrlViewModel
    {
        public Guid Id { get; set; }
        [Url]
        public string? OriginalUrl { get; set; }
        public string? ShortUrl { get; set; }
    }
}

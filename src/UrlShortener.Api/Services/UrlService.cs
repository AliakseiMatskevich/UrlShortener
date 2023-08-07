using CSharpVitamins;
using UrlShortener.Api.Interfaces;

namespace UrlShortener.Api.Services
{
    public class UrlService : IUrlService
    {
        private readonly ILogger<UrlService> _logger;
        public UrlService(ILogger<UrlService> logger)
        {

            _logger = logger;

        }
        public string CreateShortUrl(string host)
        {            
            var shortUrl = $"{host}/{(ShortGuid) Guid.NewGuid()}";
            _logger.LogInformation($"Create new short url {shortUrl}");
            return shortUrl;
        }
    }
}

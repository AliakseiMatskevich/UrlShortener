using CSharpVitamins;
using UrlShortener.Api.Interfaces;

namespace UrlShortener.Api.Services
{
    public class UrlService : IUrlService
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;
        public UrlService(/*IHttpContextAccessor httpContextAccessor*/)
        {
            //_httpContextAccessor = httpContextAccessor;
        }
        public string CreateShortUrl(string host)
        {
            //var shortUrl = $"{_httpContextAccessor.HttpContext!.Request.Scheme}://{_httpContextAccessor.HttpContext!.Request.Host}/{(ShortGuid)Guid.NewGuid()}";
            var shortUrl = $"{host}/{(ShortGuid) Guid.NewGuid()}";
            return shortUrl;
        }
    }
}

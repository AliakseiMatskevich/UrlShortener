using UrlShortener.Web.Models;

namespace UrlShortener.Web.Interfaces
{
    public interface IUrlService
    {
        IEnumerable<UrlViewModel> GetUrls();
        UrlViewModel? GetUrlByShortGuid(string shortGuid);
    }
}

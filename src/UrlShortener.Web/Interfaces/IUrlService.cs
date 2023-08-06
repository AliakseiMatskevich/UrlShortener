using UrlShortener.Web.Models;

namespace UrlShortener.Web.Interfaces
{
    public interface IUrlService
    {
        IEnumerable<UrlViewModel> GetUrls(Guid userId);
        UrlViewModel? GetUrlByShortGuid(string shortGuid);
    }
}

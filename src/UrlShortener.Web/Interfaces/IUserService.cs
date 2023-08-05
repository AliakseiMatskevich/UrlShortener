using System.Security.Claims;

namespace UrlShortener.Web.Interfaces
{
    public interface IUserService
    {
        Guid GetUserId();
    }
}

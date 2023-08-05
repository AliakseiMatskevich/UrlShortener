using Azure.Core;
using Azure;
using UrlShortener.Web.Interfaces;
using System.Security.Claims;

namespace UrlShortener.Web.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid GetUserId()
        {
            Guid userId = default;
            var httpContext = _httpContextAccessor.HttpContext!;

            if (httpContext.User.Identity!.IsAuthenticated)
            {
               return Guid.Parse(httpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            }

            if (httpContext.Request.Cookies.ContainsKey("UrlShortenerUserId"))
            {
                userId = Guid.Parse(httpContext.Request.Cookies["UrlShortenerUserId"]!);
            }

            if (userId != default) return userId;

            userId = Guid.NewGuid();
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(365);
            httpContext.Response.Cookies.Append("UrlShortenerUserId", userId.ToString(), cookieOptions);
            return userId;
        }
    }
}

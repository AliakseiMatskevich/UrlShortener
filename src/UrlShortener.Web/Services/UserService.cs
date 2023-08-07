using Azure.Core;
using Azure;
using UrlShortener.Web.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace UrlShortener.Web.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<UserService> _logger;

        public UserService(IHttpContextAccessor httpContextAccessor, 
            ILogger<UserService> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }
        public Guid GetUserId()
        {
            Guid userId = default;
            var httpContext = _httpContextAccessor.HttpContext!;
            var cookieUserId = httpContext.Request.Cookies[Constants.AnonymousUserIdCookieName];
            if (httpContext.User.Identity!.IsAuthenticated)
            {
                userId = Guid.Parse(httpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            }
            else if (cookieUserId != null)
            {
                userId = Guid.Parse(cookieUserId);
            }

            if (userId == default)
            {
                userId = Guid.NewGuid();
                SetCookieUserId(Constants.AnonymousUserIdCookieName, userId.ToString());                
            }

            _logger.LogInformation($"Get User Id {userId}");
            SetCookieUserId(Constants.CurrentUserIdCookieName, userId.ToString());

            return userId;
        }

        private void SetCookieUserId(string cookieName, string cookieValue)
        {
            var httpContext = _httpContextAccessor.HttpContext!;
            string? currentCookieValue = httpContext.Request.Cookies[cookieName];
            if (currentCookieValue != cookieValue)
            {
                _logger.LogInformation($"Set Cookie name: {cookieName} = {cookieValue}");
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.UtcNow.AddDays(365);
                httpContext.Response.Cookies.Append(cookieName, cookieValue, cookieOptions!);
            }            
        }
    }
}

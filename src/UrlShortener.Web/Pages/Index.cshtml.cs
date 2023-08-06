using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortener.Web.Interfaces;
using UrlShortener.Web.Models;

namespace UrlShortener.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUrlService _urlService;
        private readonly IUserService _userService; 

        public IndexModel(ILogger<IndexModel> logger,
            IUrlService urlService,
            IUserService userService)
        {
            _logger = logger;
            _urlService = urlService;
            _userService = userService;
        }

        public IEnumerable<UrlViewModel>? Urls = null;
       
        public IActionResult? OnGet(string? urlShortGuid = null)
        {
            if (urlShortGuid != null)
            {
                _logger.LogInformation($"Get original url by shortguid {urlShortGuid}");
                var url = _urlService.GetUrlByShortGuid(urlShortGuid);
                if (url != null)
                {
                    _logger.LogInformation($"Redirect to original url {url.OriginalUrl!}");
                    return new RedirectResult(url.OriginalUrl!);
                }
            }
            var userId = _userService.GetUserId();
            _logger.LogInformation($"Get urls for user id = {userId}");
            Urls = _urlService.GetUrls(userId);
            return default;                  
        }
    }
}
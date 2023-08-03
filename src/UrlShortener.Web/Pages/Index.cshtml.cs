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

        public IndexModel(ILogger<IndexModel> logger,
            IUrlService urlService)
        {
            _logger = logger;
            _urlService = urlService;
        }

        public IEnumerable<UrlViewModel>? Urls = null;

        public void OnGet()
        {
            Urls = _urlService.GetUrls();
        }
    }
}
using UrlShortener.Web.Interfaces;
using UrlShortener.Web.Models;

namespace UrlShortener.Web.Services
{
    public class UrlService : IUrlService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UrlService> _logger;

        public UrlService(IConfiguration configuration, 
            ILogger<UrlService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public UrlViewModel? GetUrlByShortGuid(string shortGuid)
        {
            using (var client = new HttpClient())
            {
                _logger.LogInformation($"Get url by short guid = {shortGuid}");
                client.BaseAddress = new Uri(_configuration.GetValue<string>("UrlApiUrl")!);
                //HTTP GET
                var responseTask = client.GetAsync($"Url/{shortGuid}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<UrlViewModel>();
                    readTask.Wait();

                    return readTask.Result!;
                }
                else
                {
                    return default;
                }
            }
        }

        public IEnumerable<UrlViewModel> GetUrls(Guid userId)
        {
            using (var client = new HttpClient())
            {
                _logger.LogInformation($"Get urls for user id = {userId}");
                client.BaseAddress = new Uri(_configuration.GetValue<string>("UrlApiUrl")!);
                //HTTP GET
                var responseTask = client.GetAsync($"Url/{userId}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<UrlViewModel>>();
                    readTask.Wait();

                    return readTask.Result!;
                }
                else 
                {
                    return Enumerable.Empty<UrlViewModel>();
                }
            }
        }
    }
}

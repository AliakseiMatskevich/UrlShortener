using UrlShortener.Web.Interfaces;
using UrlShortener.Web.Models;

namespace UrlShortener.Web.Services
{
    public class UrlService : IUrlService
    {
        private readonly IConfiguration _configuration;

        public UrlService(IConfiguration configuration)
        {

            _configuration = configuration;

        }
        public IEnumerable<UrlViewModel> GetUrls()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetValue<string>("UrlApiUrl")!);
                //HTTP GET
                var responseTask = client.GetAsync("Url");
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

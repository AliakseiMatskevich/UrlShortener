using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using UrlShortener.Api.Controllers;
using UrlShortener.Api.Services;

namespace UrlShortener.Tests
{
    public class UrlServiceTests
    {
        [Fact]
        public void CreateShortUrlTests()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<UrlService>>();
            UrlService urlService = new UrlService(mockLogger.Object);
            string host = "https://urlshortener.com/";

            // Act
            string result = urlService.CreateShortUrl(host);

            //Assert
            Assert.Contains(host, result);
            Assert.StartsWith(host, result);
            Assert.NotEqual(host, result);
            Assert.NotNull(result);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Api.Controllers;
using UrlShortener.Api.DTOs.Requests.Url;

namespace UrlShortener.Tests
{
    public class UrlControllerTests
    {
        [Fact]
        public async Task CreateUrlTest()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var mockLogger = new Mock<ILogger<UrlController>>();
            UrlController urlController = new UrlController(mockMediator.Object, mockLogger.Object);
            CreateUrlRequest request = new CreateUrlRequest()
            {
                Host = "https://localhost:7297/",
                OriginalUrl = "https://premierliga.pro/",
                UserId = Guid.NewGuid()
            };

            var result = await urlController.CreateUrl(request);
            
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetUrlTest()
        {

        }
    }
}

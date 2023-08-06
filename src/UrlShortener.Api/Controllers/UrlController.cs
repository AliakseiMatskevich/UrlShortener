using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Api.DTOs.Requests.Url;
using UrlShortener.Api.CQRS.Urls.Commands.CreateUrl;
using UrlShortener.Api.CQRS.Urls.Commands.DeleteUrl;
using UrlShortener.Api.Handlers.Urls.Queries.GetUrls;
using UrlShortener.Api.CQRS.Urls.Queries.GetUrlByShortGuid;
using CSharpVitamins;
using Azure.Core;

namespace UrlShortener.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UrlController> _logger;

        public UrlController(IMediator mediator, 
            ILogger<UrlController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{filter}")]
        public async Task<IActionResult> GetUrls(string filter)
        {
            if (Guid.TryParse(filter, out Guid userId))
            {
                _logger.LogInformation($"Get urls for user id = {userId}");
                var urls = await _mediator.Send(new GetUrlsQuery(userId));
                if (urls != null)
                {
                    return Ok(urls);
                }
            }
            else
            {
                _logger.LogInformation($"Get url for short guid = {filter}");
                var url = await _mediator.Send(new GetUrlByShortGuidQuery(filter));
                if (url != null)
                {
                    return Ok(url);
                }
            }

            return NotFound("No urls in database. Please add a url first.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateUrl([FromBody] CreateUrlRequest request)
        {
            _logger.LogInformation($"Create url for user id = {request.UserId}, original url = {request.OriginalUrl}");
            var url = await _mediator.Send(new CreateUrlCommand(
                request.OriginalUrl,
                request.Host,
                request.UserId));

            return Ok(url);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrl(Guid id)
        {
            _logger.LogInformation($"Delete url with id = {id}");

            await _mediator.Send(new DeleteUrlCommand(id));

            return Ok();
        }
    }
}

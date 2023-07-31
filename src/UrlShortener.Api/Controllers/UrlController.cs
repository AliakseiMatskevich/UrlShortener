using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Api.DTOs.Requests.Url;
using UrlShortener.Api.CQRS.Urls.Commands.CreateUrl;
using UrlShortener.Api.CQRS.Urls.Commands.DeleteUrl;
using UrlShortener.Api.Handlers.Urls.Queries.GetUrls;

namespace UrlShortener.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UrlController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUrls()
        {
            var urls = await _mediator.Send(new GetUrlsQuery());

            if (urls != null)
            {
                return Ok(urls);
            }

            return NotFound("No urls in database. Please add a url first.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateUrl([FromBody] CreateUrlRequest request)
        {
            var url = await _mediator.Send(new CreateUrlCommand(
                request.OriginalUrl,
                request.Host));

            return Ok(url);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrl(Guid id)
        {
            await _mediator.Send(new DeleteUrlCommand(id));

            return Ok();
        }
    }
}

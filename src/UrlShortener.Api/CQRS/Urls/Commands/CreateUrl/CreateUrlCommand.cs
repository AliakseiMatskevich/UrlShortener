using MediatR;
using UrlShortener.Api.DTOs.Responses.Url;

namespace UrlShortener.Api.CQRS.Urls.Commands.CreateUrl
{
    public class CreateUrlCommand : IRequest<CreateUrlDto>
    {
        public CreateUrlCommand(string? originalUrl, string? host)
        {
            OriginalUrl = originalUrl;
            Host = host;
        }

        public string? OriginalUrl { get; set; }
        public string? Host { get; set; }
    }
}

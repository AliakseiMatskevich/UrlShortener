using MediatR;
using UrlShortener.Api.DTOs.Responses.Url;

namespace UrlShortener.Api.CQRS.Urls.Commands.CreateUrl
{
    public class CreateUrlCommand : IRequest<CreateUrlDto>
    {
        public CreateUrlCommand(string? originalUrl, string? host, Guid userId)
        {
            OriginalUrl = originalUrl;
            Host = host;
            UserId = userId;
        }

        public string? OriginalUrl { get; set; }
        public string? Host { get; set; }
        public Guid UserId { get; set; }
    }
}

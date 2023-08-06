using MediatR;
using UrlShortener.Api.DTOs.Responses.Url;

namespace UrlShortener.Api.Handlers.Urls.Queries.GetUrls
{
    public class GetUrlsQuery : IRequest<IList<GetUrlDto>>
    {
        public GetUrlsQuery(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; set; }
    }
}

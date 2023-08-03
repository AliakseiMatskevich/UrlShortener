using MediatR;
using UrlShortener.Api.DTOs.Responses.Url;

namespace UrlShortener.Api.CQRS.Urls.Queries.GetUrlByShortGuid
{
    public class GetUrlByShortGuidQuery : IRequest<GetUrlDto>
    {
        public GetUrlByShortGuidQuery(string shortGuid)
        {
            ShortGuid = shortGuid;
        }
        public string ShortGuid { get; set; }
    }
}

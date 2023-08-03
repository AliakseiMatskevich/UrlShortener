using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Api.DTOs.Responses.Url;
using UrlShortener.Api.Handlers.Urls.Queries.GetUrls;
using UrlShortener.ApplicationCore.Entities;
using UrlShortener.ApplicationCore.Interfaces;

namespace UrlShortener.Api.CQRS.Urls.Queries.GetUrlByShortGuid
{
    public class GetUrlByShortGuidQueryHandler : IRequestHandler<GetUrlByShortGuidQuery, GetUrlDto>
    {
        private readonly IRepository<Url> _repository;
        private readonly IMapper _mapper;
        public GetUrlByShortGuidQueryHandler(IRepository<Url> repository,
                                       IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetUrlDto> Handle(GetUrlByShortGuidQuery request, CancellationToken cancellationToken)
        {
            var url = await _repository.GetEntities().Where(x => x.ShortUrl!.Contains(request.ShortGuid)).FirstOrDefaultAsync(cancellationToken);
            var urlDto = _mapper.Map<GetUrlDto>(url);

            return urlDto;
        }
    }
}

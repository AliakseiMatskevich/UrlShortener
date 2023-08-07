using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Api.DTOs.Responses.Url;
using UrlShortener.ApplicationCore.Entities;
using UrlShortener.ApplicationCore.Interfaces;

namespace UrlShortener.Api.Handlers.Urls.Queries.GetUrls
{
    public class GetUrlsQueryHandler : IRequestHandler<GetUrlsQuery, IList<GetUrlDto>>
    {
        private readonly IRepository<Url> _repository;
        private readonly IMapper _mapper;

        public GetUrlsQueryHandler(IRepository<Url> repository,
                                       IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<GetUrlDto>> Handle(GetUrlsQuery request, CancellationToken cancellationToken)
        {
            var urls = await _repository.GetEntities().Where(x => x.UserId.Equals(request.UserId)).ToListAsync(cancellationToken);
            var urlList = _mapper.Map<IList<GetUrlDto>>(urls);
                
            return urlList;
        }
    }
}

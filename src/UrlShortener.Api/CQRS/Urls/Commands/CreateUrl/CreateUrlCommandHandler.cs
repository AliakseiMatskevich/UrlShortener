using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Api.DTOs.Responses.Url;
using UrlShortener.Api.Interfaces;
using UrlShortener.ApplicationCore.Entities;
using UrlShortener.ApplicationCore.Interfaces;

namespace UrlShortener.Api.CQRS.Urls.Commands.CreateUrl
{
    public class CreateUrlCommandHandler : IRequestHandler<CreateUrlCommand, CreateUrlDto>
    {
        private readonly IRepository<Url> _repository;
        private readonly IMapper _mapper;
        private readonly IUrlService _urlService;

        public CreateUrlCommandHandler(IRepository<Url> repository,
                                       IMapper mapper,
                                       IUrlService urlService)
        {
            _repository = repository;
            _mapper = mapper;
            _urlService = urlService;
        }

        public async Task<CreateUrlDto> Handle(CreateUrlCommand request, CancellationToken cancellationToken)
        {
            var url = _mapper.Map<Url>(request);
            url.ShortUrl = _urlService.CreateShortUrl(request.Host!);
            await _repository.CreateAsync(url);

            return new CreateUrlDto(url.Id);
        }
    }
}

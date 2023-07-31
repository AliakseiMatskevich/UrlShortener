using AutoMapper;
using MediatR;
using UrlShortener.Api.DTOs.Responses.Url;
using UrlShortener.ApplicationCore.Entities;
using UrlShortener.ApplicationCore.Interfaces;

namespace UrlShortener.Api.CQRS.Urls.Commands.DeleteUrl
{

    public class DeleteUrlCommandHandler : IRequestHandler<DeleteUrlCommand>
    {
        private readonly IRepository<Url> _repository;    
        public DeleteUrlCommandHandler(IRepository<Url> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteUrlCommand request, CancellationToken cancellationToken)
        {
            var url = await _repository.GetByIdAsync(request.Id);
            if (url != null)
            {
                await _repository.DeleteAsync(url);
            }            
        }
    }
}

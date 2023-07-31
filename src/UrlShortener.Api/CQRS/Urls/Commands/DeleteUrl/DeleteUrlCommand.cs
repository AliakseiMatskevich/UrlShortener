using MediatR;
using UrlShortener.Api.DTOs.Responses.Url;

namespace UrlShortener.Api.CQRS.Urls.Commands.DeleteUrl
{
    public class DeleteUrlCommand : IRequest
    {
        public DeleteUrlCommand(Guid id)
        {
            Id = id;            
        }

        public Guid Id { get; set; }
    }
}

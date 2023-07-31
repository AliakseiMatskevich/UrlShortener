using AutoMapper;
using UrlShortener.Api.DTOs.Responses.Url;
using UrlShortener.Api.CQRS.Urls.Commands.CreateUrl;
using UrlShortener.ApplicationCore.Entities;

namespace UrlShortener.Api.MappingProfiles
{
    public class UrlProfiles : Profile
    {
        public UrlProfiles() 
        {
            CreateMap<CreateUrlCommand, Url>();
            CreateMap<Url, GetUrlDto>();
        }
    }
}

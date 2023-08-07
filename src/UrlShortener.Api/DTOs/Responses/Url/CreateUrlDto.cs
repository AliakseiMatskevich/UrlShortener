namespace UrlShortener.Api.DTOs.Responses.Url
{
    public class CreateUrlDto
    {
        public CreateUrlDto(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.ApplicationCore.Entities.Abstracts;

namespace UrlShortener.ApplicationCore.Entities
{
    public sealed class Url : BaseEntity
    {
        public string? OriginalUrl { get; set; }
        public string? ShortUrl { get; set; }
        public Guid UserId { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Entities
{
    public class UrlShortenerEntity: AuditableEntity
    {
        public long Id { get; set; }
        public string MainUrl { get; set; }
        public string ShortestUrl { get; set; }
        public string Token { get; set; }

        public ICollection<UrlShortenerAccessHistory> UrlShortenerAccessHistories { get; set; }
    }
}

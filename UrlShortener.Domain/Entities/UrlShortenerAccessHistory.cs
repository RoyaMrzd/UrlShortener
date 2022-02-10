using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Entities
{

    public class UrlShortenerAccessHistory : AuditableEntity
    {
        public long Id { get; set; }
        public long UrlShortenerEntityId { get; set; }

        public UrlShortenerEntity UrlShortenerEntity { get; set; }

    }
}

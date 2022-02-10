using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Common
{
    public class AuditableEntity
    {
        public Guid CreatorUserId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public Guid LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }
}

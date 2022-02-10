using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.UrlShorteners.Queries
{
    public class UrlShortenerItemResultQuery
    {
        public long Id { get; set; }
        public string ReturnUrl { get; set; }
    }
}

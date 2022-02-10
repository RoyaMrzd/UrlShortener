using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.UrlShorteners.Queries
{
    public class UrlShortenerListResultQuery
    {
        public string MainUrl { get; set; }
        public string ShortestUrl { get; set; }
        public int ShortestCount { get; set; }
    }
}

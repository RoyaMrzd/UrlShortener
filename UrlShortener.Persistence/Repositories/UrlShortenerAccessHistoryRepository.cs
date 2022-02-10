using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Entities;
using UrlShortener.Persistence.Interfaces;

namespace UrlShortener.Persistence.Repositories
{
    public class UrlShortenerAccessHistoryRepository : GenericRepository<UrlShortenerAccessHistory>, IUrlShortenerAccessHistoryRepository
    {
        public UrlShortenerAccessHistoryRepository(UrlShortenerDbContext context) : base(context)
        {

        }
    }
}

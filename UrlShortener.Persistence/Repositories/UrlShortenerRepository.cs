using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Entities;
using UrlShortener.Persistence.Interfaces;

namespace UrlShortener.Persistence.Repositories
{
    public class UrlShortenerRepository : GenericRepository<UrlShortenerEntity>, IUrlShortenerRepository
    {
        public UrlShortenerRepository(UrlShortenerDbContext context) : base(context)
        {

        }
    }
}

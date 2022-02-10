using UrlShortener.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UrlShortener.Persistence
{
    public interface IUrlShortenerDbContext : IDisposable
    {
        DbSet<UrlShortenerEntity> UrlShortenerEntities { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}


using UrlShortener.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.Persistence.Interfaces;

namespace UrlShortener.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IUrlShortenerDbContext _dbContext;
        public IUrlShortenerRepository UrlShorteners { get; }
        public IUrlShortenerAccessHistoryRepository UrlShortenerAccessHistories { get; }

        public UnitOfWork(IUrlShortenerDbContext dbContext,
            IUrlShortenerRepository urlShorteners,
            IUrlShortenerAccessHistoryRepository urlShortenerAccessHistories)
        {
            _dbContext = dbContext;
            UrlShorteners = urlShorteners;
            UrlShortenerAccessHistories = urlShortenerAccessHistories;
        }

        public async Task CommitChanges(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }


    }
}

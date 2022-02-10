using System;
using System.Threading;
using System.Threading.Tasks;

namespace UrlShortener.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUrlShortenerRepository UrlShorteners { get; }
        Task CommitChanges(CancellationToken cancellationToken);
    }
}

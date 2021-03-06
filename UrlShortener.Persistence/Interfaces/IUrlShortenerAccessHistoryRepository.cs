
using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Persistence.Interfaces
{
    public interface IUrlShortenerAccessHistoryRepository : IGenericRepository<UrlShortenerAccessHistory>
    {
    }
}

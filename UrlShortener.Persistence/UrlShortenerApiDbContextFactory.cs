using Microsoft.EntityFrameworkCore;

namespace UrlShortener.Persistence
{
    public class UrlShortenerApiDbContextFactory : DesignTimeDbContextFactoryBase<UrlShortenerDbContext>
    {
        protected override UrlShortenerDbContext CreateNewInstance(DbContextOptions<UrlShortenerDbContext> options)
        {
            return new UrlShortenerDbContext(options);
        }
    }
}

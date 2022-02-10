using UrlShortener.Domain.Common;
using UrlShortener.Domain.Entities;
using UrlShortener.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UrlShortener.Persistence
{
    public class UrlShortenerDbContext:DbContext, IUrlShortenerDbContext
    {
     
        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options):base(options)
        {

        }

        public DbSet<UrlShortenerEntity> UrlShortenerEntities { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatorUserId = Guid.NewGuid();
                        entry.Entity.CreationDateTime= DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedUserId = Guid.NewGuid();
                        entry.Entity.LastModifiedDateTime = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UrlShortenerEntityConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UrlShortenerDbContext).Assembly);

        }
    }
}

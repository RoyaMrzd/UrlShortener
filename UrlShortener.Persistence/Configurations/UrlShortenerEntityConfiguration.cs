
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Persistence.Configuration
{
    internal class UrlShortenerEntityConfiguration : IEntityTypeConfiguration<UrlShortenerEntity>
    {
        public void Configure(EntityTypeBuilder<UrlShortenerEntity> builder)
        {
            builder.ToTable("UrlShortener");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreationDateTime).IsRequired();
            builder.Property(x => x.CreatorUserId).IsRequired();
            builder.Property(x => x.LastModifiedUserId);
            builder.Property(x => x.LastModifiedDateTime);
            builder.Property(x => x.MainUrl).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ShortestUrl).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Token).IsRequired();
            builder.HasMany(e => e.UrlShortenerAccessHistories).WithOne(pe => pe.UrlShortenerEntity).HasForeignKey(en => en.UrlShortenerEntityId);
        }
    }
}
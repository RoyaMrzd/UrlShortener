using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Persistence.Configurations
{
    internal class UrlShortenerAccessHistoryConfiguration : IEntityTypeConfiguration<UrlShortenerAccessHistory>
    {
        public void Configure(EntityTypeBuilder<UrlShortenerAccessHistory> builder)
        {
            builder.ToTable("UrlShortenerAccessHistory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreationDateTime).IsRequired();
            builder.Property(x => x.CreatorUserId).IsRequired();
            builder.Property(x => x.UrlShortenerEntityId).IsRequired();
            builder.HasOne(e => e.UrlShortenerEntity).WithMany(pe => pe.UrlShortenerAccessHistories).HasForeignKey(e => e.UrlShortenerEntityId);

        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common.Catalogs;

namespace UMIS.DAL.Domain.ModelsConfigurator.Catalogs
{
    public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.HasOne(x => x.CatalogType)
                .WithMany(x => x.Catalog)
                .HasForeignKey(y => y.CatalogTypeId);

            builder.HasMany(x => x.CatalogToCatalogFields)
                .WithOne(x => x.Catalog)
                .HasForeignKey(y => y.CatalogId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<Catalog> builder)
        {
        }
    }
}

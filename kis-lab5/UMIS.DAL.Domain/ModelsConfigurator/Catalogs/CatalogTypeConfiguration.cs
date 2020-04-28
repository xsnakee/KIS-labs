using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common.Catalogs;

namespace UMIS.DAL.Domain.ModelsConfigurator.Catalogs
{
    public class CatalogTypeConfiguration : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder)
        {
            builder.HasMany(x => x.Catalog)
                .WithOne(x => x.CatalogType)
                .HasForeignKey(y => y.CatalogTypeId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<CatalogType> builder)
        {
        }
    }
}

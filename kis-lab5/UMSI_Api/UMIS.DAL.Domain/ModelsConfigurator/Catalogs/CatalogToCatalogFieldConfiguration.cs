using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common.Catalogs.RelationsEntityModels;

namespace UMIS.DAL.Domain.ModelsConfigurator.Catalogs
{
    public class CatalogToCatalogFieldConfiguration : IEntityTypeConfiguration<CatalogToCatalogField>
    {
        public void Configure(EntityTypeBuilder<CatalogToCatalogField> builder)
        {
            builder.HasKey(x => new { x.CatalogId, x.CatalogFieldId});

            builder.HasOne(x => x.Catalog)
                .WithMany(x => x.CatalogToCatalogFields)
                .HasForeignKey(y => y.CatalogId);

            builder.HasOne(x => x.CatalogField)
                .WithMany(x => x.CatalogToCatalogFields)
                .HasForeignKey(y => y.CatalogFieldId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<CatalogToCatalogField> builder)
        {
        }
    }
}

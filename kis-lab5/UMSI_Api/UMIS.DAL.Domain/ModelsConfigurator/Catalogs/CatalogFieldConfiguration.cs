using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common.Catalogs;

namespace UMIS.DAL.Domain.ModelsConfigurator.Catalogs
{
    public class CatalogFieldConfiguration : IEntityTypeConfiguration<CatalogField>
    {
        public void Configure(EntityTypeBuilder<CatalogField> builder)
        {
            builder.HasMany(x => x.CatalogToCatalogFields)
                .WithOne(x => x.CatalogField)
                .HasForeignKey(y => y.CatalogFieldId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<CatalogField> builder)
        {
        }
    }
}

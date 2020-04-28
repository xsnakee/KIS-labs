using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common.Catalogs;

namespace UMIS.DAL.Domain.ModelsConfigurator.Catalogs
{
    public class CatalogFieldValueConfiguration : IEntityTypeConfiguration<CatalogFieldValue>
    {
        public void Configure(EntityTypeBuilder<CatalogFieldValue> builder)
        {
            builder.HasOne(x => x.CatalogToCatalogField);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<CatalogFieldValue> builder)
        {
        }
    }
}

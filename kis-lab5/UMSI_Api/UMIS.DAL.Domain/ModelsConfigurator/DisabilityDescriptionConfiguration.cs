using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common;

namespace UMIS.DAL.Domain.ModelsConfigurator
{
    public class DisabilityDescriptionConfiguration : IEntityTypeConfiguration<DisabilityDescription>
    {
        public void Configure(EntityTypeBuilder<DisabilityDescription> builder)
        {
            builder.HasOne(x => x.Patient)
                .WithOne(x => x.DisabilityDescription)
                .HasForeignKey<Patient>(x => x.DisabilityDescriptionId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<DisabilityDescription> builder)
        {
        }
    }
}

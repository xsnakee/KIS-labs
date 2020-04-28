using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common;

namespace UMIS.DAL.Domain.ModelsConfigurator
{
    public class AllergyAnamnesisConfiguration : IEntityTypeConfiguration<AllergyAnamnesis>
    {
        public void Configure(EntityTypeBuilder<AllergyAnamnesis> builder)
        {
            builder.HasOne(x => x.Patient)
                .WithOne(y => y.AllergyAnamnesis)
                .HasForeignKey<Patient>(x => x.AllergyAnamnesisId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<AllergyAnamnesis> builder)
        {
        }
    }
}

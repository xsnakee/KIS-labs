using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common;

namespace UMIS.DAL.Domain.ModelsConfigurator
{
    public class MediacalAnamnesisConfiguration : IEntityTypeConfiguration<MediacalAnamnesis>
    {
        public void Configure(EntityTypeBuilder<MediacalAnamnesis> builder)
        {
            builder.HasOne(x => x.MedicalHistory)
                .WithMany(x => x.MedicalAnamneses)
                .HasForeignKey(x => x.MedicalHistoryId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<MediacalAnamnesis> builder)
        {
        }
    }
}

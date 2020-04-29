using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common;

namespace UMIS.DAL.Domain.ModelsConfigurator
{
    public class DiagnosisConfiguration : IEntityTypeConfiguration<Diagnosis>
    {
        public void Configure(EntityTypeBuilder<Diagnosis> builder)
        {
            builder.HasOne(x => x.MedicalHistory)
                .WithMany(x => x.Diagnoses)
                .HasForeignKey(x => x.MedicalHistoryId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<Diagnosis> builder)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common;

namespace UMIS.DAL.Domain.ModelsConfigurator
{
    public class MedicalHistoryConfiguration : IEntityTypeConfiguration<MedicalHistory>
    {
        public void Configure(EntityTypeBuilder<MedicalHistory> builder)
        {
            builder.HasOne(x => x.Patient)
                .WithMany(y => y.MedicalHistories)
                .HasForeignKey(x => x.PatientId);

            builder.HasMany(x => x.MedicalAnamneses)
                .WithOne(y => y.MedicalHistory)
                .HasForeignKey(x => x.MedicalHistoryId);

            builder.HasMany(x => x.PhysiologicalIndications)
                .WithOne(y => y.MedicalHistory)
                .HasForeignKey(x => x.MedicalHistoryId);

            builder.HasMany(x => x.MedicalExaminations)
                .WithOne(y => y.MedicalHistory)
                .HasForeignKey(x => x.MedicalHistoryId);

            builder.HasMany(x => x.PhysicalExaminations)
                .WithOne(y => y.MedicalHistory)
                .HasForeignKey(x => x.MedicalHistoryId);

            builder.HasMany(x => x.Diagnoses)
                .WithOne(y => y.MedicalHistory)
                .HasForeignKey(x => x.MedicalHistoryId);

            builder.HasMany(x => x.Notes)
                .WithOne(y => y.MedicalHistory)
                .HasForeignKey(x => x.MedicalHistoryId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<MedicalHistory> builder)
        {
        }
    }
}

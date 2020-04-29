using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common;

namespace UMIS.DAL.Domain.ModelsConfigurator
{
    public class MedicalExaminationConfiguration : IEntityTypeConfiguration<MedicalExamination>
    {
        public void Configure(EntityTypeBuilder<MedicalExamination> builder)
        {
            builder.HasOne(x => x.MedicalHistory)
                .WithMany(y => y.MedicalExaminations)
                .HasForeignKey(x => x.MedicalHistoryId);

            builder.HasMany(x => x.MedicalTestResults)
                .WithOne(y => y.MedicalExamination)
                .HasForeignKey(x => x.MedicalExaminationId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<MedicalExamination> builder)
        {
        }
    }
}

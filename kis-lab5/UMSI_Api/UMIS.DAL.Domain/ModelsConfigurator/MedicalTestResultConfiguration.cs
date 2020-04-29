using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common;

namespace UMIS.DAL.Domain.ModelsConfigurator
{
    public class MedicalTestResultConfiguration : IEntityTypeConfiguration<MedicalTestResult>
    {
        public void Configure(EntityTypeBuilder<MedicalTestResult> builder)
        {
            builder.HasOne(x => x.MedicalExamination)
                .WithMany(y => y.MedicalTestResults)
                .HasForeignKey(x => x.MedicalExaminationId);

            builder.HasOne(x => x.Patient)
                .WithMany()
                .HasForeignKey(x => x.PatientId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<MedicalTestResult> builder)
        {
        }
    }
}

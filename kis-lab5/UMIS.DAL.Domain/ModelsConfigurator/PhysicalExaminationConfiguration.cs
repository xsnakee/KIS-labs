using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common;

namespace UMIS.DAL.Domain.ModelsConfigurator
{
    public class PhysicalExaminationConfiguration : IEntityTypeConfiguration<PhysicalExamination>
    {
        public void Configure(EntityTypeBuilder<PhysicalExamination> builder)
        {
            builder.HasOne(x => x.MedicalHistory)
                .WithMany(y => y.PhysicalExaminations)
                .HasForeignKey(x => x.MedicalHistoryId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<PhysicalExamination> builder)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common;

namespace UMIS.DAL.Domain.ModelsConfigurator
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasOne(x => x.MedicalHistory)
                .WithMany(y => y.Assignments)
                .HasForeignKey(x => x.MedicalHistoryId);

            builder.HasOne(x => x.MedicalTestResult)
                .WithOne()
                .HasForeignKey<Assignment>(x => x.MedicalTestResultId);

            builder.HasOne(x => x.MedicalExaminationResult)
                .WithOne()
                .HasForeignKey<Assignment>(x => x.PhysiologicalExaminationId);

            builder.HasOne(x => x.PhysiologicalExaminationResult)
                .WithOne()
                .HasForeignKey<Assignment>(x => x.PhysiologicalExaminationId);

            builder.HasOne(x => x.PhysiologicalIndicationResult)
                .WithOne()
                .HasForeignKey<Assignment>(x => x.PhysiologicalIndicationId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<Assignment> builder)
        {
        }
    }
}

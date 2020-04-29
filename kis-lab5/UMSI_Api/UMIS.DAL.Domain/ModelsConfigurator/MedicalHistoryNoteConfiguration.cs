using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common;

namespace UMIS.DAL.Domain.ModelsConfigurator
{
    public class MedicalHistoryNoteConfiguration : IEntityTypeConfiguration<MedicalHistoryNote>
    {
        public void Configure(EntityTypeBuilder<MedicalHistoryNote> builder)
        {
            builder.HasOne(x => x.MedicalHistory)
                .WithMany(y => y.Notes)
                .HasForeignKey(x => x.MedicalHistoryId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<MedicalHistoryNote> builder)
        {
        }
    }
}

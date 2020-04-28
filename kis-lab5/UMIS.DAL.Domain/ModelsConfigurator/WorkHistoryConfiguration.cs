using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common;

namespace UMIS.DAL.Domain.ModelsConfigurator
{
    public class WorkHistoryConfiguration : IEntityTypeConfiguration<WorkHistory>
    {
        public void Configure(EntityTypeBuilder<WorkHistory> builder)
        {
            builder.HasOne(x => x.Patient)
                .WithOne(x => x.WorkHistory)
                .HasForeignKey<Patient>(x => x.WorkHistoryId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<WorkHistory> builder)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Common;

namespace UMIS.DAL.Domain.ModelsConfigurator
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasOne(x => x.DisabilityDescription)
                .WithOne(y => y.Patient)
                .HasForeignKey<DisabilityDescription>(x => x.PatientId);

            builder.HasOne(x => x.WorkHistory)
                .WithOne(y => y.Patient)
                .HasForeignKey<WorkHistory>(x => x.PatientId);

            builder.HasOne(x => x.AllergyAnamnesis)
                .WithOne(y => y.Patient)
                .HasForeignKey<AllergyAnamnesis>(x => x.PatientId);

            builder.HasMany(x => x.MedicalHistories)
                .WithOne(y => y.Patient)
                .HasForeignKey(x => x.PatientId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<Patient> builder)
        {
        }
    }
}

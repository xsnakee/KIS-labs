using Microsoft.EntityFrameworkCore;
using UMIS.DAL.Domain.Contracts.Models.Common;
using UMIS.DAL.Domain.Contracts.Models.Common.Catalogs;
using UMIS.DAL.Domain.ModelsConfigurator;
using UMIS.DAL.Domain.ModelsConfigurator.Catalogs;

namespace UMIS.DAL.Domain
{
    public class CommonDbContext : DbContext
    {
        public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected CommonDbContext() : base()
        {
        }

        #region Catalogs
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<CatalogField> CatalogFields { get; set; }
        public DbSet<CatalogFieldValue> CatalogFieldValues { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        #endregion


        public DbSet<AllergyAnamnesis> AllergyAnamneses { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<DisabilityDescription> DisabilityDescriptions { get; set; }
        public DbSet<MediacalAnamnesis> MediacalAnamneses { get; set; }
        public DbSet<MedicalExamination> MedicalExaminations { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<MedicalHistoryNote> MedicalHistoryNotes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PhysicalExamination> PhysicalExaminations { get; set; }
        public DbSet<PhysiologicalIndication> PhysiologicalIndications { get; set; }
        public DbSet<WorkHistory> WorkHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Catalogs
            modelBuilder.ApplyConfiguration(new CatalogConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogFieldConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogFieldValueConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogToCatalogFieldConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogTypeConfiguration());
            #endregion

            modelBuilder.ApplyConfiguration(new AllergyAnamnesisConfiguration());
            modelBuilder.ApplyConfiguration(new DiagnosisConfiguration());
            modelBuilder.ApplyConfiguration(new DisabilityDescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new MediacalAnamnesisConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalExaminationConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new PhysicalExaminationConfiguration());
            modelBuilder.ApplyConfiguration(new PhysiologicalIndicationConfiguration());
            modelBuilder.ApplyConfiguration(new WorkHistoryConfiguration());
        }

    }
}

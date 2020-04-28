using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;

namespace UMIS.DAL.DomainAuth.ModelsConfigurator
{
    public class RoleToWorkgroupModelConfiguration : IEntityTypeConfiguration<RoleToWorkgroup>
    {
        public void Configure(EntityTypeBuilder<RoleToWorkgroup> builder)
        {
            builder.ToTable("RoleToWorkgroup");
            //builder.HasKey(x => x.Id );

            builder.HasOne(u => u.Workgroup)
                .WithMany(u => u.RoleToWorkgroup)
                .HasForeignKey(ur => ur.WorkgroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Role)
                .WithMany(u => u.RoleToWorkgroup)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<RoleToWorkgroup> builder)
        {
            DateTime defultDate = DateTime.MinValue;
            builder.HasData(
                new RoleToWorkgroup
                {
                    Id = 1,
                    WorkgroupId = 1, // System Workgroup
                    RoleId = 1 // Admin Role
                },
                new RoleToWorkgroup
                {
                    Id = 2,
                    WorkgroupId = 1,
                    RoleId = 2
                }
            );
        }
    }
}

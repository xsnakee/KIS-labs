using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;

namespace UMIS.DAL.DomainAuth.ModelsConfigurator
{
    public class PermissionsToWorkgroupRoleModelConfiguration : IEntityTypeConfiguration<PermissionsToWorkgroupRole>
    {
        public void Configure(EntityTypeBuilder<PermissionsToWorkgroupRole> builder)
        {
            builder.HasKey(x => new { x.PermissionId, x.RoleToWorkgroupId });

            builder.HasOne(pwr => pwr.Permission)
                .WithMany(p => p.PermissionsToWorkgroupRole)
                .HasForeignKey(pwr => pwr.PermissionId);

            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<PermissionsToWorkgroupRole> builder)
        {
            DateTime defultDate = DateTime.MinValue;
            builder.HasData(
                new PermissionsToWorkgroupRole
                {
                    PermissionId = 1,
                    RoleToWorkgroupId = 1
                }
            );
        }
    }
}

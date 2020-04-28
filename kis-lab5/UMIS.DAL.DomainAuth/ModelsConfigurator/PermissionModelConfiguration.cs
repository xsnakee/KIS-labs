using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Auth;

namespace UMIS.DAL.DomainAuth.ModelsConfigurator
{
    public class PermissionModelConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<Permission> builder)
        {
            DateTime defultDate = DateTime.MinValue;
            builder.HasData(
                new Permission
                {
                    Id = 1,
                    CreateDate = defultDate,
                    LastModificationDate = defultDate,
                    IsSystem = true,
                    OwnerId = 1,
                    Name = "Полный доступ",
                    AllowedOnlyForOwner = true,
                    EntityTypeNum = int.MaxValue,
                    ActionTypeNum = int.MaxValue
                }
            );
        }
    }
}

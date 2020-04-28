using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Auth;

namespace UMIS.DAL.DomainAuth.ModelsConfigurator
{
    public class RoleModelConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("AspNetRoles");
            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<Role> builder)
        {
            DateTime defultDate = DateTime.MinValue;
            builder.HasData(
                new Role
                {
                    Id = 1,
                    CreateDate = defultDate,
                    LastModificationDate = defultDate,
                    IsSystem = true,
                    OwnerId = 1,
                    Name = "Администратор",
                    NormalizedName = "Администратор".ToUpper(),
                    AllowedOnlyForOwner = true
                },
                new Role
                {
                    Id = 2,
                    CreateDate = defultDate,
                    LastModificationDate = defultDate,
                    IsSystem = true,
                    OwnerId = 1,
                    Name = "Главный врач",
                    NormalizedName = "Главный врач".ToUpper(),
                    AllowedOnlyForOwner = true
                }
            );
        }
    }
}

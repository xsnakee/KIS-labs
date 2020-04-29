using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Auth;

namespace UMIS.DAL.DomainAuth.ModelsConfigurator
{
    public class WorkgroupModelConfiguration : IEntityTypeConfiguration<Workgroup>
    {
        public void Configure(EntityTypeBuilder<Workgroup> builder)
        {
            this.Seed(builder);
        }

        public void Seed(EntityTypeBuilder<Workgroup> builder)
        {
            DateTime defultDate = DateTime.MinValue;
            builder.HasData(
                new Workgroup
                {
                    Id = 1,
                    CreateDate = defultDate,
                    LastModificationDate = defultDate,
                    IsSystem = true,
                    OwnerId = 1,
                    Name = "System",
                    AllowedOnlyForOwner = true
                }
            );
        }
    }
}

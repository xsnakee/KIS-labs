using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Auth;

namespace UMIS.DAL.DomainAuth.ModelsConfigurator
{
    public class UserModelConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("AspNetUsers");
            //this.Seed(builder);
        }

        // TODO: Работает не правильно, так как не проставляются все поля в том числе и security stamp
        public void Seed(EntityTypeBuilder<User> builder)
        {
            DateTime defaultDate = DateTime.MinValue;
            builder.HasData(
                new User
                {
                    Id = 1,
                    CreateDate = defaultDate,
                    LastModificationDate = defaultDate,
                    IsSystem = true,
                    OwnerId = 1,
                    UserName = "UmisAdmin",
                    NormalizedUserName = "UmisAdmin".ToUpper(),
                    AllowedOnlyForOwner = true
                },
                new User
                {
                    Id = 2,
                    CreateDate = defaultDate,
                    LastModificationDate = defaultDate,
                    IsSystem = true,
                    OwnerId = 1,
                    UserName = "UmisChiefDoctor",
                    NormalizedUserName = "UmisChiefDoctor".ToUpper(),
                    AllowedOnlyForOwner = true
                }
            );
        }
    }
}

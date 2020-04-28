using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;

namespace UMIS.DAL.DomainAuth.ModelsConfigurator
{
    public class UserToRoleWorkgroupModelConfiguration : IEntityTypeConfiguration<UserToRoleWorkgroup>
    {
        public void Configure(EntityTypeBuilder<UserToRoleWorkgroup> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoleToWorkgroupId });

            builder.HasOne(urw => urw.User)
                .WithMany(r => r.UserToRoleWorkgroup)
                .HasForeignKey(urw => urw.UserId);

            builder.HasOne(urw => urw.RoleToWorkgroup);
        }
    }
}

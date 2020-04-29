using System.Linq;
using AutoMapper;
using UMIS.BLL.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;

namespace UMIS.BLL.AppServices.Automapper.Profiles
{
    public class UmisAutomapperProfile : Profile
    {
        public UmisAutomapperProfile()
        {
            CreateMap<User, UserAuthInfoDto>()
                .ForMember(x => x.Roles, d => d.MapFrom(y => y.UserToRoleWorkgroup
                                                .Select(x => x.RoleToWorkgroup.Role)
                                                .ToList()))
                .ForMember(x => x.Workgroups, d => d.MapFrom(y => y.UserToRoleWorkgroup
                                                .Select(x => x.RoleToWorkgroup.Workgroup)
                                                .ToList()))
                .ForMember(x => x.Permissions, d => d.Ignore());

            CreateMap<Permission, PermissionDto>()
                .ForMember(x => x.EntityTypeTitle, d => d.Ignore());

            CreateMap<RoleDto, Role>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.AllowedOnlyForOwner, y => y.MapFrom(z => z.AllowedOnlyForOwner))
                .ForAllOtherMembers(x => x.Ignore());
            CreateMap<Role, RoleDto>();

            CreateMap<Workgroup, WorkgroupDto>()
                .ForMember(x => x.Roles, d => d.MapFrom(y => y.RoleToWorkgroup
                                                .Select(x => x.Role)
                                                .ToList()));
            CreateMap<WorkgroupDto, Workgroup>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<UserRegistrationDto, User>()
                .ForMember(x => x.UserName, d => d.MapFrom(y => y.UserName))
                .ForMember(x => x.Email, d => d.MapFrom(y => y.Email))
                .ForMember(x => x.IsSystem, d => d.MapFrom(y => false))
                .ForMember(x => x.PhoneNumber, d => d.MapFrom(y => y.PhoneNumber))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<PermissionsToWorkgroupRole, WorkgroupRolePermissionDto>()
                .ForMember(x => x.Id, d => d.MapFrom(y => y.RoleToWorkgroupId))
                .ForMember(x => x.Role, d => d.MapFrom(y => y.RoleToWorkgroup.Role))
                .ForMember(x => x.Workgroup, d => d.MapFrom(y => y.RoleToWorkgroup.Workgroup));
        }
    }
}

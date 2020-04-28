using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions;
using Common.Models.Filters;
using Common.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using UMIS.BLL.AppServices._Base;
using UMIS.BLL.AppServices.Helpers;
using UMIS.BLL.Contracts.Models.Auth;
using UMIS.BLL.Contracts.ServicesAbstraction;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth;

namespace UMIS.BLL.AppServices.Auth
{
    /// <summary>
    /// Менеджер по работе с ролями
    /// </summary>
    public class RoleManager : BaseManager, IRoleManager
    {
        protected readonly IRoleRepository _roleRepository;
        protected readonly RoleManager<Role> _identityRoleManager;

        public RoleManager(IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            IRoleRepository roleRepository,
            RoleManager<Role> identityRoleManager)
            : base(httpContextAccessor, mapper)
        {
            _roleRepository = roleRepository;
            _identityRoleManager = identityRoleManager;
        }

        /// <inheritdoc />
        public async Task<List<RoleDto>> GetRolesForUserEditAsync()
        {
            List<Role> result = await _roleRepository
                .GetAllForOwnerList<Role>(UserId);

            return Mapper.Map<List<RoleDto>>(result.OrderBy(x => x.Name));
        }

        /// <inheritdoc />
        public async Task<PaginationResult<RoleDto>> GetRolesByFilterAsync(BaseFilter filter)
        {
            PaginationResult<Role> result = await _roleRepository
                .GetRolesWithPermissionsByFilterAsync(filter);

            return result.Convert<Role, RoleDto>(Mapper);
        }

        /// <inheritdoc />
        public async Task<PaginationResult<WorkgroupRolePermissionDto>> GetWorkgroupsRolesWithPermissionsAsync(BaseFilter filter)
        {
            PaginationDictionaryResult<RoleToWorkgroup, List<Permission>> dictionaryResult = await _roleRepository
                   .GetWorkgroupsRolesWithPermissionsAsync(filter);

            PaginationResult<WorkgroupRolePermissionDto> result = new PaginationResult<WorkgroupRolePermissionDto>
            {
                Items = new List<WorkgroupRolePermissionDto>(),
                CurrentPage = dictionaryResult.CurrentPage,
                TotalPages = dictionaryResult.TotalPages,
                TotalRecords = dictionaryResult.TotalRecords
            };

            foreach (KeyValuePair<RoleToWorkgroup, List<Permission>> item in dictionaryResult.Items)
            {
                result.Items.Add(new WorkgroupRolePermissionDto
                {
                    Id = item.Key.Id,
                    Role = Mapper.Map<RoleDto>(item.Key.Role),
                    Workgroup = Mapper.Map<WorkgroupDto>(item.Key.Workgroup),
                    Permissions = Mapper.Map<List<PermissionDto>>(item.Value)
                });
            }

            return result;
        }

        /// <inheritdoc />
        public async Task<int> CreateRoleAsync(RoleDto roleDto)
        {
            Role domainRole = Mapper.Map<Role>(roleDto);
            domainRole.OwnerId = UserId;
            IdentityResult result = await _identityRoleManager.CreateAsync(domainRole);

            if (!result.Succeeded)
            {
                throw new ValidationException(new ValidationResult(result.Errors.ConvertToValidationResult()));
            }

            RoleToWorkgroup roleToWorkgroup = await _roleRepository
                .AddRoleToWorkgroup(domainRole.Id, null);
            await _roleRepository.SaveChangesAsync();

            return domainRole.Id;
        }
    }
}

using AutoMapper;
using Common.Enums;
using Common.Exceptions;
using Common.Models.Filters;
using Common.Models.Results;
using Common.Resources.Messages;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    /// Менеджер по работе с пермиссиями
    /// </summary>
    public class PermissionManager : BaseManager, IPermissionManager
    {
        protected readonly IPermissionRepository _permissionRepository;
        protected readonly IRoleRepository _roleRepository;
        protected readonly IRoleToWorkgroupRepository _roleToWorkgroupRepository;

        public PermissionManager(IHttpContextAccessor httpContextAccessor, 
            IMapper mapper,
            IPermissionRepository permissionRepository,
            IRoleToWorkgroupRepository roleToWorkgroupRepository,
            IRoleRepository roleRepository) 
            : base(httpContextAccessor, mapper)
        {
            _permissionRepository = permissionRepository;
            _roleRepository = roleRepository;
            _roleToWorkgroupRepository = roleToWorkgroupRepository;
        }

        /// <inheritdoc />
        public async Task<List<PermissionDto>> GetPermissionsForUserEditAsync()
        {
            List<Permission> permissions = await _permissionRepository
                .GetPermissionsForUserEditAsync(UserId);

            return Mapper.Map<List<PermissionDto>>(permissions);
        }

        /// <inheritdoc />
        public async Task<PaginationResult<WorkgroupRolePermissionDto>> GetPermissionsWithWorkgroupRolesAsync(BaseFilter filter)
        {
            PaginationDictionaryResult<RoleToWorkgroup, List<Permission>> dictionaryResult = await _permissionRepository
                .GetPermissionsWithWorkgroupRolesAsync(filter);

            PaginationResult<WorkgroupRolePermissionDto> result = new PaginationResult<WorkgroupRolePermissionDto>
            {
                Items = new List<WorkgroupRolePermissionDto>(),
                CurrentPage = dictionaryResult.CurrentPage,
                TotalPages = dictionaryResult.TotalPages,
                TotalRecords = dictionaryResult.TotalRecords
            };

            foreach(KeyValuePair<RoleToWorkgroup, List<Permission>> item in dictionaryResult.Items)
            {
                result.Items.Add(new WorkgroupRolePermissionDto
                {
                    Role = Mapper.Map<RoleDto>(item.Key.Role),
                    Workgroup = Mapper.Map<WorkgroupDto>(item.Key.Workgroup),
                    Permissions = Mapper.Map<List<PermissionDto>>(item.Value)
                });
            }

            return result;
        }

        /// <inheritdoc />
        public async Task<int> CreateOrEditRoleWorkgroupPermissionsAsync(RoleToWorkroupDto workgroupRole)
        {
            RoleToWorkgroup domainWorkgroupRole = await _permissionRepository
                .GetByRoleAndWorkgroupIds(workgroupRole.RoleId, workgroupRole.WorkgroupId);

            if (domainWorkgroupRole != null)
            {
                return domainWorkgroupRole.Id;
            }

            RoleToWorkgroup roleToWorkgroup = await _roleRepository
                .AddRoleToWorkgroup(workgroupRole.RoleId, workgroupRole.WorkgroupId);
            await _roleRepository.SaveChangesAsync();

            return roleToWorkgroup.Id;
        }

        /// <inheritdoc />
        public async Task<List<PermissionDto>> GetPermissionsByWorkgroupRoleIdAsync(int workgroupRoleId)
        {
            List<Permission> result = await _permissionRepository
                .GetPermissionsByWorkgroupRoleAsync(workgroupRoleId);

            return Mapper.Map<List<PermissionDto>>(result);
        }

        /// <inheritdoc />
        public async Task UpdateWorkgroupRolePermissionsAsync(int workgroupRoleId, List<int> permissionsIds)
        {
            // TODO: Добавить проверка на возможность добавлять текущем пользователем указанных пермиссий
            await _permissionRepository.ExecuteInTransactionAsync(async () =>
            {
                RoleToWorkgroup domainWorkgroupRole = await _roleToWorkgroupRepository
                    .GetByIdWithPermissionsAsync(workgroupRoleId);

                if (domainWorkgroupRole == null)
                {
                    throw new CustomException(
                        string.Format(Messages.Exception_EntityNotFoundTemplate,
                            EntityTypeEnum.Role,
                            workgroupRoleId
                        ));
                }

                domainWorkgroupRole.Permissions.Clear();
                await _roleToWorkgroupRepository.SaveChangesAsync();

                foreach (int permissionId in permissionsIds)
                {
                    domainWorkgroupRole.Permissions.Add(new PermissionsToWorkgroupRole
                    {
                        PermissionId = permissionId,
                        RoleToWorkgroupId = workgroupRoleId
                    });
                }

                await _roleToWorkgroupRepository.UpdateAndSaveAsync(domainWorkgroupRole);
            });
        }

        /// <inheritdoc />  
        public async Task<bool> WorkgroupRoleSoftDeleteAsync(int id)
        {
            return await _roleToWorkgroupRepository
                .DeleteToggleMarkAsync(id, delete: true);
        }
    }
}

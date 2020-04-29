using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Common.Models.Filters;
using Common.Models.Results;
using Microsoft.EntityFrameworkCore;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth;
using UMIS.DAL.DomainAuth;

namespace UMIS.DAL.Repositories.Auth
{
    public class PermissionRepository : AuthRepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(AuthDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Переорпделение метода добавления или обновления системных пермиссий
        /// </summary>
        /// <param name="entity">Пермиссия</param>
        public override async Task AddOrUpdateAsync(Permission entity)
        {
            Permission existetEntity = await GetAsync(entity.Id);

            if (existetEntity != null)
            {
                existetEntity.Name = entity.Name;
                existetEntity.PermissionsToWorkgroupRole = entity.PermissionsToWorkgroupRole;
                existetEntity.IsRemoved = entity.IsRemoved;
                existetEntity.IsSystem = entity.IsSystem;
                existetEntity.OwnerId = entity.OwnerId;
                existetEntity.AllowedOnlyForOwner = entity.AllowedOnlyForOwner;
                existetEntity.ActionTypeNum = entity.ActionTypeNum;
                existetEntity.EntityTypeNum = entity.EntityTypeNum;

                _entitySet.Update(existetEntity);
            }
            else
            {
                await AddAsync(entity);
            }
        }

        /// <summary>
        /// Получить доступные пермиссии для роли в рабочей группе
        /// </summary>
        /// <param name="roleId">Идентификатор роли</param>
        /// <param name="workgroupId">Идентификатор рабочей группы</param>
        /// <returns>Список пермиссий</returns>
        public async Task<List<Permission>> GetPermissionsByWorkgroupRoleAsync(int roleToWorkgroupId)
        {
            DbContext.ChangeTracker.AutoDetectChangesEnabled = false;

            return await DbContext
                .PermissionsToWorkgroupRoles
                .Where(p => (p.RoleToWorkgroupId == roleToWorkgroupId))
                .Select(p => p.Permission)
                .ToListAsync();
        }

        /// <summary>
        /// Получить доступные пермиссии для роли в рабочей группе
        /// </summary>        
        /// <param name="workgroupRolesIds">Идентификаторы ролей в рабочих группах пользователя</param>
        /// <returns>Список пермиссий</returns>
        public async Task<List<Permission>> GetPermissionsByWorkgroupsRolesAsync(List<int> workgroupRolesIds)
        {
            DbContext.ChangeTracker.AutoDetectChangesEnabled = false;

            return await DbContext
                .PermissionsToWorkgroupRoles
                .Include(x => x.Permission)
                .Where(p => (workgroupRolesIds.Contains(p.RoleToWorkgroupId)))
                .Select(x => x.Permission)
                .ToListAsync();
        }


        /// <summary>
        /// Получить доступные пермиссии для пользователя по идентификатору
        /// </summary>
        /// <param name="currentUserId">Идентификатор пользователя</param>
        /// <returns>Список пермиссий</returns>
        public async Task<List<Permission>> GetPermissionsByUserIdAsync(int currentUserId)
        {
            DbContext.ChangeTracker.AutoDetectChangesEnabled = false;

            return await DbContext
                .PermissionsToWorkgroupRoles
                .Include(x => x.Permission)
                .Include(pwr => pwr.RoleToWorkgroup)
                    .ThenInclude(wr => wr.UserToRoleWorkgroup)
                .Where(p => p.RoleToWorkgroup.UserToRoleWorkgroup
                            .Select(x => x.UserId)
                            .Contains(currentUserId))
                .Select(x => x.Permission)
                .ToListAsync();
        }

        /// <summary>
        /// Получить список пермиссий по типам сущностей и действий
        /// </summary>
        /// <param name="permissions"> Список кортежей типов сущнойстей и действий</param>
        /// <returns> Список пермиссий </returns>
        public async Task<List<Permission>>
            GetPermissionsByEntityActionTypesAsync(List<KeyValuePair<int?, int?>> permissions)
        {
            IQueryable<Permission> query = _entitySet;

            foreach (var kv in permissions)
            {
                query = query.Union(_entitySet
                    .Where(x => x.EntityTypeNum == kv.Key
                        && x.ActionTypeNum == kv.Value));
            }

            return await query
                .ToListAsync();
        }

        /// <summary>
        /// Получить пермиссии для создания/редактирования ролей/рабочих групп
        /// </summary>
        /// <param name="ownerId">Идентификатор пользователя</param>
        /// <returns>Список пермиссий</returns>
        public async Task<List<Permission>> GetPermissionsForUserEditAsync(int ownerId)
        {
            return await GetAllForOwner<Permission>(ownerId)
                .ToListAsync();
        }

        /// <summary>
        /// Получить постраничный список ролей с пермиссиями для просмотра
        /// </summary>
        /// <param name="filter">Модель фильтра</param>
        /// <returns>Постраничный результат</returns>
        public async Task<PaginationDictionaryResult<RoleToWorkgroup, List<Permission>>> GetPermissionsWithWorkgroupRolesAsync(BaseFilter filter)
        {
            if (filter == null)
            {
                return new PaginationDictionaryResult<RoleToWorkgroup, List<Permission>>();
            }

            IQueryable<PermissionsToWorkgroupRole> query = DbContext.Set<PermissionsToWorkgroupRole>()
                .Include(x => x.Permission)
                .Include(x => x.RoleToWorkgroup)
                    .ThenInclude(y => y.Role)
                .Include(x => x.RoleToWorkgroup)
                    .ThenInclude(y => y.Workgroup);

            // Поиск по названию ролей и рабочих групп
            if (!string.IsNullOrWhiteSpace(filter.KeyWords))
            {
                query = query.Where(x =>
                    x.RoleToWorkgroup.Role.NormalizedName
                        .StartsWith(filter.KeyWords.ToUpper())
                    || x.RoleToWorkgroup.Workgroup.Name.ToUpper()
                        .StartsWith(filter.KeyWords.ToUpper()));
            }

            if (!filter.WithRemoved)
            {
                query = query.Where(x => !x.RoleToWorkgroup.Role.IsRemoved 
                    && !x.RoleToWorkgroup.Workgroup.IsRemoved);
            }

            int totalItemsCount;

            if (!string.IsNullOrWhiteSpace(filter?.SortField)
                && IsValidSortFieldAndDirection(typeof(PermissionsToWorkgroupRole), filter.SortField, filter.SortDirection))
            {
                query = query.OrderBy
                (
                    string.Format("{0} {1}", filter.SortField, filter.SortDirection)
                );
            }
            else
            {
                query = query.OrderBy(o => o.RoleToWorkgroup.WorkgroupId)
                    .ThenBy(o => o.RoleToWorkgroup.RoleId);
            }

            var dictionaryQuery = query.GroupBy(x => x.RoleToWorkgroup);

            dictionaryQuery = Paginate(dictionaryQuery, filter.PageNumber, filter.PageSize, out totalItemsCount);

            return new PaginationDictionaryResult<RoleToWorkgroup, List<Permission>>
            {
                Items = await dictionaryQuery
                    .ToDictionaryAsync(x => x.Key, y => y.Select(z => z.Permission).ToList()),
                TotalPages = CalcTotalPagesCount(totalItemsCount, filter.PageSize),
                TotalRecords = totalItemsCount,
                CurrentPage = filter.PageNumber
            };
        }

        /// <inheritdoc />
        public async Task<RoleToWorkgroup> GetByRoleAndWorkgroupIds(int? roleId, int? workgroupId)
        {
            return await DbContext.Set<RoleToWorkgroup>()
                .FirstOrDefaultAsync(x => x.RoleId == roleId && x.WorkgroupId == workgroupId);
        }

        /// <inheritdoc />
        public async Task<int> AddAndSavePermissionsToWorkgroupRoleAsync(int workgroupRoleId, params int[] permissionIds)
        {
            foreach (int permissionId in permissionIds)
            {
                DbContext.Set<PermissionsToWorkgroupRole>()
                .Update(new PermissionsToWorkgroupRole
                {
                    RoleToWorkgroupId = workgroupRoleId,
                    PermissionId = permissionId
                });
            }

            return await DbContext.SaveChangesAsync();
        }
    }
}
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
    /// <summary>
    /// Репозиторий для работы с рабочими группами
    /// </summary>
    public class RoleRepository : AuthRepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(AuthDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Получить постраничный список ролей с пермиссиями для просмотра
        /// </summary>
        /// <param name="filter">Модель фильтра</param>
        /// <returns>Постраничный результат</returns>
        public async Task<PaginationResult<Role>> GetRolesWithPermissionsByFilterAsync(BaseFilter filter)
        {
            if (filter == null)
            {
                return new PaginationResult<Role>();
            }

            IQueryable<Role> query = GetAll(false)
                .Include(x => x.RoleToWorkgroup)
                    .ThenInclude(y => y.Permissions)
                        .ThenInclude(z => z.Permission);

            if (!string.IsNullOrWhiteSpace(filter.KeyWords))
            {
                query = query.Where(x =>
                    x.NormalizedName
                        .Contains(filter.KeyWords.ToUpper()));
            }

            if (!filter.WithRemoved)
            {
                query = query.Where(x => !x.IsRemoved);
            }

            int totalItemsCount;
            query = GetQueryByFilterBasic(query,
                    new BaseFilter
                    {
                        SortDirection = filter.SortDirection,
                        SortField = filter.SortField
                    });
            query = Paginate(query, filter.PageNumber, filter.PageSize, out totalItemsCount);

            return new PaginationResult<Role>
            {
                Items = await query.ToListAsync(),
                TotalPages = CalcTotalPagesCount(totalItemsCount, filter.PageSize),
                TotalRecords = totalItemsCount,
                CurrentPage = filter.PageNumber
            };
        }

        /// <inheritdoc />
        public async Task<RoleToWorkgroup> AddRoleToWorkgroup(int? roleId, int? workgroupId)
        {
            RoleToWorkgroup roleWorkgroup = new RoleToWorkgroup
            {
                RoleId = roleId,
                WorkgroupId = workgroupId
            };

            return (await DbContext.AddAsync(roleWorkgroup)).Entity;
        }

        /// <summary>
        /// Получить постраничный список ролей с пермиссиями для просмотра
        /// </summary>
        /// <param name="filter">Модель фильтра</param>
        /// <returns>Постраничный результат</returns>
        public async Task<PaginationDictionaryResult<RoleToWorkgroup, List<Permission>>> GetWorkgroupsRolesWithPermissionsAsync(BaseFilter filter)
        {
            if (filter == null)
            {
                return new PaginationDictionaryResult<RoleToWorkgroup, List<Permission>>();
            }

            IQueryable<RoleToWorkgroup> query = DbContext.Set<RoleToWorkgroup>()
                .Include(x => x.Role)
                .Include(x => x.Workgroup)
                .Include(x => x.Permissions)
                    .ThenInclude(y => y.Permission);

            // Поиск по названию ролей и рабочих групп
            if (!string.IsNullOrWhiteSpace(filter.KeyWords))
            {
                query = query.Where(x =>
                    x.Role.NormalizedName
                        .Contains(filter.KeyWords.ToUpper())
                    || x.Workgroup.Name.ToUpper()
                        .Contains(filter.KeyWords.ToUpper()));
            }

            if (!filter.WithRemoved)
            {
                query = query.Where(x => !x.IsRemoved
                    && !x.Role.IsRemoved
                    && !x.Workgroup.IsRemoved);
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
                query = query.OrderBy(o => o.WorkgroupId)
                    .ThenBy(o => o.RoleId);
            }

            var dictionaryQuery = query.GroupBy(x => x);
            dictionaryQuery = Paginate(dictionaryQuery, filter.PageNumber, filter.PageSize, out totalItemsCount);

            return new PaginationDictionaryResult<RoleToWorkgroup, List<Permission>>
            {
                Items = await dictionaryQuery
                    .ToDictionaryAsync(x => x.Key, y => y
                        .SelectMany(z => z
                            .Permissions
                            .Select(p => p.Permission).ToList())
                        .ToList()),
                TotalPages = CalcTotalPagesCount(totalItemsCount, filter.PageSize),
                TotalRecords = totalItemsCount,
                CurrentPage = filter.PageNumber
            };
        }

        /// <inheritdoc />
        public async Task<bool> IsExistAsync(Role role)
        {
            Role entity = await GetAll()
                .FirstOrDefaultAsync(x => x.Id == role.Id
                    || x.Name == role.Name);

            return entity != null
                ? true
                : false;
        }
    }
}

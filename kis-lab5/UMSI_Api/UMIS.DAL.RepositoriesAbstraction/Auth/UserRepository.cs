using System.Linq;
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
    /// Репозитория для работы с учетными данными пользователей
    /// </summary>
    public class UserRepository : AuthRepositoryBase<User>, IUserRepository
    {
        public UserRepository(AuthDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Добавить пользователя к роли в рабочей группе
        /// </summary>w
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="roleWorkgroupId">Идентификатор роли в рабочей группе</param>
        public async Task AddUserToRoleAndWorkgroupAsync(int userId, int? roleWorkgroupId)
        {
            await DbContext.Set<UserToRoleWorkgroup>()
                .AddAsync(new UserToRoleWorkgroup
                {
                    RoleToWorkgroupId = roleWorkgroupId,
                    UserId = userId
                });
            await SaveChangesAsync();
        }

        /// <summary>
        /// Проверить существование роли у пользоавтеля
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="roleWorkgroupId">Идентификатор роли в рабочей группе</param>
        /// <returns>Отметка о существовании</returns>
        public async Task<bool> IsExistUserToRoleAndWorkgroupAsync(int userId, int? roleWorkgroupId)
        {
            return await DbContext.Set<UserToRoleWorkgroup>()
                .AnyAsync(x => x.UserId == userId && x.RoleToWorkgroupId == roleWorkgroupId);
        }

        /// <summary>
        /// Получить пользователя по имени со связанными данными
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <returns>Сущность пользователя</returns>
        public async Task<User> GetUserByNameWithRelatedDataAsync(string userName)
        {
            string normalizedName = userName.ToUpper();
            return await GetAll()
                    .Include(x => x.UserToRoleWorkgroup)
                        .ThenInclude(w => w.RoleToWorkgroup)
                            .ThenInclude(rw => rw.Role)
                    .Include(x => x.UserToRoleWorkgroup)
                        .ThenInclude(w => w.RoleToWorkgroup)
                            .ThenInclude(rw => rw.Workgroup)
                .FirstOrDefaultAsync(u => u.NormalizedUserName == normalizedName);
        }

        /// <inheritdoc />
        public async Task<PaginationResult<User>> GetUsersAuthDataByFilterAsync(BaseFilter filter)
        {
            if (filter == null)
            {
                return new PaginationResult<User>();
            }

            IQueryable<User> query = GetAll(false)
                .Include(x => x.UserToRoleWorkgroup)
                    .ThenInclude(y => y.RoleToWorkgroup)
                        .ThenInclude(z => z.Role)
                .Include(x => x.UserToRoleWorkgroup)
                    .ThenInclude(y => y.RoleToWorkgroup)
                        .ThenInclude(z => z.Workgroup);

            if (!string.IsNullOrWhiteSpace(filter.KeyWords))
            {
                query = query.Where(x =>
                    x.NormalizedUserName
                        .Contains(filter.KeyWords.ToUpper())
                    || x.NormalizedEmail
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

            return new PaginationResult<User>
            {
                Items = await query.ToListAsync(),
                TotalPages = CalcTotalPagesCount(totalItemsCount, filter.PageSize),
                TotalRecords = totalItemsCount,
                CurrentPage = filter.PageNumber
            };
        }
    }
}

using UMIS.DAL.Domain.Contracts.Models.Base;
using UMIS.DAL.DomainAuth;
using UMIS.DAL.RepositoriesAbstraction.Base;

namespace UMIS.DAL.Repositories.Auth
{
    public class AuthRepositoryBase<TEntity> : RepositoryBase<AuthDbContext, TEntity, int>
        where TEntity : class, IBaseEntity<int>
    {
        public AuthRepositoryBase(AuthDbContext context) : base(context)
        {
        }
    }
}

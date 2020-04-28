using UMIS.DAL.Domain;
using UMIS.DAL.Domain.Contracts.Models.Base;
using UMIS.DAL.RepositoriesAbstraction.Base;

namespace UMIS.DAL.Repositories.Common
{
    public class CommonRepositoryBase<TEntity> : RepositoryBase<CommonDbContext, TEntity, int>
        where TEntity : class, IBaseEntity<int>
    {
        public CommonRepositoryBase(CommonDbContext context) : base(context)
        {
        }
    }
}

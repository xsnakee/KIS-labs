using UMIS.DAL.Domain;
using UMIS.DAL.Domain.Contracts.Models.Base;
using UMIS.DAL.RepositoriesAbstraction.Base;

namespace UMIS.DAL.Repositories.Base
{
    public class CommonRepositoryBase<TEntity> : RepositoryBase<CommonDbContext, TEntity, int>
        where TEntity : class, IBaseEntity<int>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        public CommonRepositoryBase(CommonDbContext context) : base(context)
        {
        }
    }
}

using UMIS.DAL.Contracts.RepositoriesAbstraction.Base;
using UMIS.DAL.Domain.Contracts.Models.Common;

namespace UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Common
{
    /// <summary>
    /// Репозиторий для работы с историями болезни.
    /// </summary>
    public interface IMedicalHistoryRepository : IRepositoryBase<MedicalHistory, int>
    {
    }
}

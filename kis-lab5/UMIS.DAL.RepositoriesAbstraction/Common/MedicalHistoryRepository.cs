using System;
using UMIS.DAL.Domain;
using UMIS.DAL.Domain.Contracts.Models.Common;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Common;
using UMIS.DAL.Repositories.Base;

namespace UMIS.DAL.Repositories.Common
{
    /// <summary>
    /// репозиторий для работы c историями болезней
    /// </summary>
    public class MedicalHistoryRepository : CommonRepositoryBase<MedicalHistory>, IMedicalHistoryRepository
    { 
        public MedicalHistoryRepository(CommonDbContext context) : base(context)
        {

        }
    }
}

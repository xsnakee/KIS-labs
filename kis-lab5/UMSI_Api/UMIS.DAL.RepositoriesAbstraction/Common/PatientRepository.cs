using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UMIS.DAL.Domain;
using UMIS.DAL.Domain.Contracts.Models.Common;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Common;
using UMIS.DAL.Repositories.Base;

namespace UMIS.DAL.Repositories.Common
{
    /// <summary>
    /// репозиторий для работы с пацинетами
    /// </summary>
    public class PatientRepository : CommonRepositoryBase<Patient>, IPatientRepository
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        public PatientRepository(CommonDbContext context) : base(context)
        {
        }

        /// <inheritdoc />
        public override async Task<Patient> GetWithRelationshipAsync(int id)
        {
            return await _entitySet
                .Include(p => p.AllergyAnamnesis)
                .Include(p => p.DisabilityDescription)
                .Include(p => p.MedicalHistories)
                .Include(p => p.WorkHistory)
                .Include(p => p.Values)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

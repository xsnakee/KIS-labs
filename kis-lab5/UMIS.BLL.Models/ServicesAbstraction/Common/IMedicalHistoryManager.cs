using System.Threading.Tasks;
using Common.Models.Filters;
using Common.Models.Results;
using UMIS.BLL.Contracts.Models.Common;
using UMIS.BLL.Contracts.Models.Views.Common;
using UMIS.BLL.Contracts.ServicesAbstraction._Base;

namespace UMIS.BLL.Contracts.ServicesAbstraction.Common
{
    /// <summary>
    /// Менеджер для работы c историей болезни
    /// </summary>
    public interface IMedicalHistoryManager : IBaseManager
    {
    
        /// <summary>
        /// Создать новую историю болезни.
        /// </summary>
        /// <param name="medicalHistory">История болезни.</param>
        /// <returns>Присвоенный идентификатор истории болезни.</returns>
        Task<int> CreateMedicalHistoryAsync(MedicalHistoryDto medicalHistory);

        /// <summary>
        /// Получить историю болезни по идентфиру.
        /// </summary>
        /// <param name="id">Идентификатор истории болезни.</param>
        /// <returns>Пациент</returns>
        Task<MedicalHistoryForViewDto> GetMedicalHistoryByIdAsync(int id);

        /// <summary>
        /// Получить постраничный список существующих историй болезней.
        /// </summary>
        /// <param name="filter">Фильтр</param>
        /// <returns>Постраничный список пациентов</returns>
        Task<PaginationResult<MedicalHistoryForViewDto>> GetMedicalHistoriesByFilterAsync(BaseFilter filter);

    }
}

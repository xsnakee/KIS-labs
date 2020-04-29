using System.Threading.Tasks;
using Common.Models.Filters;
using Common.Models.Results;
using UMIS.BLL.Contracts.Models.Common;
using UMIS.BLL.Contracts.Models.Views.Common;
using UMIS.BLL.Contracts.ServicesAbstraction._Base;

namespace UMIS.BLL.Contracts.ServicesAbstraction.Common
{
    /// <summary>
    /// Менеджер для работы с пациентами
    /// </summary>
    public interface IPatientManager : IBaseManager
    {
        /// <summary>
        /// Получить данные пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пациента</param>
        /// <returns>Пациент</returns>
        Task<PatientForViewDto> GetPatientByIdAsync(int id);

        /// <summary>
        /// Зарегистрировать нового пациента
        /// </summary>
        /// <param name="patient">Пациент</param>
        /// <returns>Присвоенный идентификатор пациента</returns>
        Task<int> RegisterPatientAsync(PatientDto patient);

        /// <summary>
        /// Получить постраничный список пациентов
        /// </summary>
        /// <param name="filter">Фильтр</param>
        /// <returns>Постраничный список пациентов</returns>
        Task<PaginationResult<PatientForViewDto>> GetPatientsByFilterAsync(BaseFilter filter);

        /// <summary>
        /// Обновить данные пациента
        /// </summary>
        /// <param name="patient">Пациент</param>
        Task EditPatientAsync(PatientDto patient);
    }
}

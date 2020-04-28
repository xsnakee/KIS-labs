using System.Collections.Generic;
using UMIS.DAL.Domain.Contracts.Models.Base;
using UMIS.DAL.Domain.Contracts.Models.Common.Catalogs;

namespace UMIS.DAL.Domain.Contracts.Models.Common.Base
{
    /// <summary>
    /// Обертка значения из справочника
    /// </summary>
    public interface IBaseCommonEntity : IBaseEntity<int>
    {
        /// <summary>
        /// Значение из каталога
        /// </summary>
        IList<CatalogFieldValue> Values { get; set; }
    }
}

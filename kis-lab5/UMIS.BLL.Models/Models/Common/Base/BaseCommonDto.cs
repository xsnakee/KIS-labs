using System.Collections.Generic;
using UMIS.BLL.Contracts.Models.Base;

namespace UMIS.BLL.Contracts.Models.Common.Catalogs.Base
{
    /// <summary>
    /// Обертка значения из справочника
    /// </summary>
    public class BaseCommonDto : BaseDtoWithTimestamp, IBaseCommonDto
    {
        /// <summary>
        /// Значение из каталога
        /// </summary>
        //public IList<CatalogFieldValueDto> Values { get; set; }
    }
}

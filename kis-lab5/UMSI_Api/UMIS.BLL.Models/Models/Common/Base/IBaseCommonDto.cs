using System.Collections.Generic;
using UMIS.BLL.Contracts.Models.Base;

namespace UMIS.BLL.Contracts.Models.Common.Catalogs.Base
{
    /// <summary>
    /// Обертка значения из справочника
    /// </summary>
    public interface IBaseCommonDto : IBaseDto<int>
    {
        /// <summary>
        /// Значение из каталога
        /// </summary>
        //IList<CatalogFieldValueDto> Values { get; set; }
    }
}

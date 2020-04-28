using System.Collections.Generic;
using UMIS.BLL.Contracts.Models.Base;
using UMIS.BLL.Contracts.Models.Common.Catalogs.RelationsEntityDto;

namespace UMIS.BLL.Contracts.Models.Common.Catalogs
{
    /// <summary>
    /// Справочник
    /// </summary>
    public class CatalogDto : BaseDtoWithTimestamp
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CatalogDto()
        {
            CatalogToCatalogFields = new List<CatalogToCatalogFieldDto>();
        }

        /// <summary>
        /// Тип каталога
        /// </summary>
        public CatalogTypeDto CatalogType { get; set; }

        /// <summary>
        /// Название справочника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Поля справочника
        /// </summary>
        public IList<CatalogToCatalogFieldDto> CatalogToCatalogFields { get; set; }

    }
}

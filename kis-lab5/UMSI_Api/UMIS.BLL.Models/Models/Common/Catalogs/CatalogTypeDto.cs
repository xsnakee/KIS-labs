using System.Collections.Generic;
using UMIS.BLL.Contracts.Models.Base;

namespace UMIS.BLL.Contracts.Models.Common.Catalogs
{
    /// <summary>
    /// Тип справочника
    /// </summary>
    public class CatalogTypeDto : BaseDtoWithTimestamp
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CatalogTypeDto()
        {
            Catalog = new List<CatalogDto>();
        }

        /// <summary>
        /// Название типа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Каталог
        /// </summary>
        public IList<CatalogDto> Catalog { get; set; }

    }
}

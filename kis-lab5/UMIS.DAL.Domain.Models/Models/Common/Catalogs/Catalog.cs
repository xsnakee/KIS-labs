using System.Collections.Generic;
using UMIS.DAL.Domain.Contracts.Models.Base;
using UMIS.DAL.Domain.Contracts.Models.Common.Catalogs.RelationsEntityModels;

namespace UMIS.DAL.Domain.Contracts.Models.Common.Catalogs
{
    /// <summary>
    /// Справочник
    /// </summary>
    public class Catalog : BaseCustomizeEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Catalog()
        {
            CatalogToCatalogFields = new List<CatalogToCatalogField>();
        }

        /// <summary>
        /// Тип каталога
        /// </summary>
        public CatalogType CatalogType { get; set; }

        public int CatalogTypeId { get; set; }

        /// <summary>
        /// Название справочника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Поля справочника
        /// </summary>
        public IList<CatalogToCatalogField> CatalogToCatalogFields { get; set; }

    }
}

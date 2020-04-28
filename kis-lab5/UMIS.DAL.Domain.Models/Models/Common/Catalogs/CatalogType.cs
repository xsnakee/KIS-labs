using System.Collections.Generic;
using UMIS.DAL.Domain.Contracts.Models.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Common.Catalogs
{
    /// <summary>
    /// Тип справочника
    /// </summary>
    public class CatalogType : BaseCustomizeEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CatalogType()
        {
            Catalog = new List<Catalog>();
        }

        /// <summary>
        /// Название типа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Каталог
        /// </summary>
        public IList<Catalog> Catalog { get; set; }

    }
}

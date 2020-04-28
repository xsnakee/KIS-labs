using System.Collections.Generic;
using Common.Enums;
using UMIS.DAL.Domain.Contracts.Models.Base;
using UMIS.DAL.Domain.Contracts.Models.Common.Catalogs.RelationsEntityModels;

namespace UMIS.DAL.Domain.Contracts.Models.Common.Catalogs
{
    /// <summary>
    /// Поле справочника
    /// </summary>
    public class CatalogField : BaseCustomizeEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CatalogField()
        {
            CatalogToCatalogFields = new List<CatalogToCatalogField>();
        }

        /// <summary>
        /// Название поля
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип данных
        /// </summary>
        public DataTypeEnum DataType { get; set; }

        /// <summary>
        /// Справочники
        /// </summary>
        public IList<CatalogToCatalogField> CatalogToCatalogFields { get; set; }
    }
}

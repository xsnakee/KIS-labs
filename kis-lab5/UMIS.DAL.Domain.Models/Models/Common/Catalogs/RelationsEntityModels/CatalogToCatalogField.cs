using UMIS.DAL.Domain.Contracts.Models.Common.Catalogs;

namespace UMIS.DAL.Domain.Contracts.Models.Common.Catalogs.RelationsEntityModels
{
    /// <summary>
    /// Связь справоника и его полей
    /// </summary>
    public class CatalogToCatalogField
    {
        /// <summary>
        /// Справочник
        /// </summary>
        public Catalog Catalog { get; set; }
        public int CatalogId { get; set; }

        /// <summary>
        /// Поле справочника
        /// </summary>
        public CatalogField CatalogField { get; set; }
        public int CatalogFieldId { get; set; }

        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// Значение по умолчанию (используется из диапазона)
        /// </summary>
        public string DefaultValue2 { get; set; }

        /// <summary>
        /// Единица измерения
        /// </summary>
        public string Units { get; set; }
    }
}

namespace UMIS.BLL.Contracts.Models.Common.Catalogs.RelationsEntityDto
{
    /// <summary>
    /// Связь справоника и его полей
    /// </summary>
    public class CatalogToCatalogFieldDto
    {
        /// <summary>
        /// Справочник
        /// </summary>
        public CatalogDto Catalog { get; set; }
        public int CatalogId { get; set; }

        /// <summary>
        /// Поле справочника
        /// </summary>
        public CatalogFieldDto CatalogField { get; set; }
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

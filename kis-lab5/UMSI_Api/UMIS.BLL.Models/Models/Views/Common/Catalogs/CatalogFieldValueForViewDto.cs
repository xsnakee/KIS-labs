using Common.Enums;

namespace UMIS.BLL.Contracts.Models.Views.Common.Catalogs
{
    /// <summary>
    /// Значение из справочника 
    /// </summary>
    public class CatalogFieldValueForViewDto
    {
        /// <summary>
        /// Название поля
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Тип данных
        /// </summary>
        public DataTypeEnum DataType { get; set; }

        /// <summary>
        /// Тип каталога
        /// </summary>
        public string CatalogTypeName { get; set; }

        /// <summary>
        /// Название справочника
        /// </summary>
        public string CatalogName { get; set; }

        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// Значение по умолчанию (используется из диапазона)
        /// </summary>
        public string DefaultValue2 { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Значение2 (используется для диапазонов)
        /// </summary>
        public string Value2 { get; set; }

        /// <summary>
        /// Единица измерения
        /// </summary>
        public string Units { get; set; }
    }
}
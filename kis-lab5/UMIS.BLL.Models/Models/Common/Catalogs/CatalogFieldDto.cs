using Common.Enums;
using UMIS.BLL.Contracts.Models.Base;
using UMIS.BLL.Contracts.Models.Common.Catalogs.RelationsEntityDto;

namespace UMIS.BLL.Contracts.Models.Common.Catalogs
{
    /// <summary>
    /// Поле справочника
    /// </summary>
    public class CatalogFieldDto : BaseDtoWithTimestamp
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CatalogFieldDto()
        {
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
        /// Отношение справочника к полю справочника
        /// </summary>
        public CatalogToCatalogFieldDto CatalogToCatalogField { get; set; }
        public int CatalogToCatalogFieldId { get; set; }
    }
}
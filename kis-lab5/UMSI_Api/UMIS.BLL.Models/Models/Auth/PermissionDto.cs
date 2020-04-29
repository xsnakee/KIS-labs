using Common.Enums;
using Common.Helpers;
using UMIS.BLL.Contracts.Models.Base;

namespace UMIS.BLL.Contracts.Models.Auth
{
    public class PermissionDto : BaseDto
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Типа сущности
        /// </summary>
        public int? EntityTypeNum { get; set; }

        /// <summary>
        /// Описание типа сущности
        /// </summary>
        public string EntityTypeTitle {
            get
            {
                return AttributesHelper.GetDescriptionAttribute((EntityTypeEnum) EntityTypeNum);
            }
        }

        /// <summary>
        /// Тип действия
        /// </summary>
        public int? ActionTypeNum { get; set; }
    }
}

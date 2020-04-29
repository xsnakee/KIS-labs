using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;
using UMIS.DAL.Domain.Contracts.Models.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Auth
{
    public class Role : IdentityRole<int>, IBaseCustomizeEntity, IBaseEntity<int>
    {
        public Role()
        {
            RoleToWorkgroup = new List<RoleToWorkgroup>();
        }

        /// <summary>
        /// Принадлежность к рабочим группам
        /// </summary>
        public virtual List<RoleToWorkgroup> RoleToWorkgroup { get; set; }

        /// <summary>
        /// Идентификатор создателя сущности
        /// </summary>
        public int OwnerId { get; set; } = 1; // Id - 1, зарезервированно администратором

        /// <summary>
        /// Сущность является системной
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Пометка удаления
        /// </summary>
        public bool IsRemoved { get; set; }

        /// <summary>
        /// Имеет доступ только создатель сущности
        /// </summary>
        public bool AllowedOnlyForOwner { get; set; }

        /// <summary>
        /// Дата создания объекта
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Дата последнего изменения
        /// </summary>
        public DateTime LastModificationDate { get; set; }
    }
}

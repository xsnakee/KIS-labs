using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;
using UMIS.DAL.Domain.Contracts.Models.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Auth
{
    public class User : IdentityUser<int>, IBaseEntity<int> , IBaseCustomizeEntity
    {
        public User()
        {
            UserToRoleWorkgroup = new List<UserToRoleWorkgroup>();
        }

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

        /// <summary>
        /// Роли рабочих групп пользователя
        /// </summary>
        public virtual List<UserToRoleWorkgroup> UserToRoleWorkgroup { get; set; }
    }
}

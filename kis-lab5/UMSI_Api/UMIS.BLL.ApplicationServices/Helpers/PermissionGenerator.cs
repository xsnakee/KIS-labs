using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Common.Attributes;
using Common.Enums;
using UMIS.DAL.Domain.Contracts.Models.Auth;

namespace UMIS.DbSeed.Helpers
{
    /// <summary>
    /// Класс для генерации пермиссий на осоновании сущностей из перчислений EntityTypeEnum и возомжных действий PermissionsActionEnum
    /// </summary>
    public class PermissionGenerator
    {
        // OPTIMIZATION: Требуется выгрузка пермиссий в Редис
        public readonly static List<Permission> Permissions;

        static PermissionGenerator()
        {
            Permissions = GeneratePermissions();
        }

        protected static List<Permission> GeneratePermissions()
        {
            List<Permission> result = new List<Permission>();
            DateTime defaultDateTime = DateTime.MinValue;
            Type permissionType = typeof(PermissionsActionEnum);
            Type entityType = typeof(EntityTypeEnum);
            FieldInfo[] permissionFields = permissionType.GetFields();
            FieldInfo[] entityTypesFields = entityType.GetFields();

            int id = 2; // 1 - зарегистрирована для администратора с полным доступом
            foreach (EntityTypeEnum entityTypeVal in entityType.GetEnumValues())
            {
                string entityFieldName = entityType.GetEnumName(entityTypeVal);
                FieldInfo entityField = entityType.GetField(entityFieldName);
                int entityTypeNum = (int)entityTypeVal;
                DescriptionAttribute entityDescriptionAttribute =
                    entityField.GetCustomAttribute(typeof(DescriptionAttribute), true) as DescriptionAttribute;
                string entityName = entityDescriptionAttribute.Description;
                OnlyForOwnerAttribute entityAllowedAccessAttribute = entityField.GetCustomAttribute(typeof(OnlyForOwnerAttribute), true)
                    as OnlyForOwnerAttribute;
                bool entityAllowedAccess = entityAllowedAccessAttribute?.OnlyForOwner ?? false;

                foreach (PermissionsActionEnum actionVal in permissionType.GetEnumValues())
                {
                    string actionFieldName = permissionType.GetEnumName(actionVal);
                    FieldInfo actionField = permissionType.GetField(actionFieldName);
                    int actionNum = (int)actionVal;
                    DescriptionAttribute actionDescriptionAttribute =
                        actionField.GetCustomAttribute(typeof(DescriptionAttribute), true) as DescriptionAttribute;
                    string actionName = actionDescriptionAttribute.Description;
                    OnlyForOwnerAttribute actionAllowedAccessAttribute = actionField.GetCustomAttribute(typeof(OnlyForOwnerAttribute), true)
                        as OnlyForOwnerAttribute;
                    bool actionAllowedAccess = actionAllowedAccessAttribute?.OnlyForOwner ?? false;

                    result.Add(new Permission
                    {
                        Id = id++, // проставляется для соответствия в бд
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1, // admin user
                        IsRemoved = false,
                        ActionTypeNum = actionNum,
                        EntityTypeNum = entityTypeNum,
                        IsSystem = true,
                        Name = $"{actionName} {entityName}",
                        AllowedOnlyForOwner = entityAllowedAccess || actionAllowedAccess
                    });
                }
            }

            return result;
        }
    }
}

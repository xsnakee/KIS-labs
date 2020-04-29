using System;
using System.Collections.Generic;
using Common.Enums;
using UMIS.DAL.Domain.Contracts.Models.Auth;

namespace UMIS.DbSeed.DataSeed
{
    public static class Permissions
    {
        private static DateTime defaultDateTime = DateTime.UtcNow;

        public static List<Permission> PermissionsForSeed { get; } = new List<Permission>()
        { 
            //Полный доступ
            new Permission{
                        Id = 1,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = int.MaxValue,
                        ActionTypeNum = int.MaxValue,
                        IsSystem = true,
                        Name = "Полный доступ",
                        AllowedOnlyForOwner = false
                    },
            //Просмотр общедоступных данных пользователей
            new Permission{
                        Id = 2,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.User,
                        ActionTypeNum = (int?)PermissionsActionEnum.View,
                        IsSystem = true,
                        Name = "Просмотр общедоступных данных пользователей",
                        AllowedOnlyForOwner = false
                    },
            //Просмотр учетных данных пользователей
            new Permission{
                        Id = 3,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.User,
                        ActionTypeNum = (int?)PermissionsActionEnum.DeepView,
                        IsSystem = true,
                        Name = "Просмотр учетных данных пользователей",
                        AllowedOnlyForOwner = true
                    },
            //Создание пользовательских учетных записей
            new Permission{
                        Id = 4,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.User,
                        ActionTypeNum = (int?)PermissionsActionEnum.Create,
                        IsSystem = true,
                        Name = "Создание пользовательских учетных записей",
                        AllowedOnlyForOwner = false
                    },
            //Обновление данных пользователя
            new Permission{
                        Id = 5,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.User,
                        ActionTypeNum = (int?)PermissionsActionEnum.Update,
                        IsSystem = true,
                        Name = "Обновление учетных данных пользователей",
                        AllowedOnlyForOwner = false
                    },
            //Редактирование учетных данных пользователей
            new Permission{
                        Id = 6,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.User,
                        ActionTypeNum = (int?)PermissionsActionEnum.Edit,
                        IsSystem = true,
                        Name = "Редактирование учетных данных пользователей",
                        AllowedOnlyForOwner = true
                    },
            //Блокировка пользовательских аккаунтов
            new Permission{
                        Id = 7,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.User,
                        ActionTypeNum = (int?)PermissionsActionEnum.SoftDelete,
                        IsSystem = true,
                        Name = "Блокировка и пользовательских аккаунтов",
                        AllowedOnlyForOwner = false
                    },
            //Удаление пользовательских аккаунтов
            new Permission{
                        Id = 8,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.User,
                        ActionTypeNum = (int?)PermissionsActionEnum.Delete,
                        IsSystem = true,
                        Name = "Удаление пользовательских аккаунтов",
                        AllowedOnlyForOwner = true
                    },
            //Просмотр ролей
            new Permission{
                        Id = 9,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Role,
                        ActionTypeNum = (int?)PermissionsActionEnum.View,
                        IsSystem = true,
                        Name = "Просмотр общедоступных данных ролей",
                        AllowedOnlyForOwner = false
                    },
            //Просмотр полной информации о роли
            new Permission{
                        Id = 10,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Role,
                        ActionTypeNum = (int?)PermissionsActionEnum.DeepView,
                        IsSystem = true,
                        Name = "Просмотр учетных данных ролей",
                        AllowedOnlyForOwner = true
                    },
            //Создание ролей
            new Permission{
                        Id = 11,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Role,
                        ActionTypeNum = (int?)PermissionsActionEnum.Create,
                        IsSystem = true,
                        Name = "Создание пользовательских ролей",
                        AllowedOnlyForOwner = false
                    },
            //Назначение ролей пользователям
            new Permission{
                        Id = 12,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Role,
                        ActionTypeNum = (int?)PermissionsActionEnum.Update,
                        IsSystem = true,
                        Name = "Выдача ролей пользователям",
                        AllowedOnlyForOwner = false
                    },
            //Редактирование ролей
            new Permission{
                        Id = 13,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Role,
                        ActionTypeNum = (int?)PermissionsActionEnum.Edit,
                        IsSystem = true,
                        Name = "Редактирование ролей",
                        AllowedOnlyForOwner = true
                    },
            //Блокировка ролей
            new Permission{
                        Id = 14,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Role,
                        ActionTypeNum = (int?)PermissionsActionEnum.SoftDelete,
                        IsSystem = true,
                        Name = "Отключение пользовательских ролей",
                        AllowedOnlyForOwner = true
                    },
            //Удаление ролей
            new Permission{
                        Id = 15,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Role,
                        ActionTypeNum = (int?)PermissionsActionEnum.Delete,
                        IsSystem = true,
                        Name = "Удаление ролей",
                        AllowedOnlyForOwner = true
                    },
            //Просмотр рабочих групп
            new Permission{
                        Id = 16,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Workgroup,
                        ActionTypeNum = (int?)PermissionsActionEnum.View,
                        IsSystem = true,
                        Name = "Просмотр общедоступных данных данных рабочих групп",
                        AllowedOnlyForOwner = false
                    },
            //Просмотр полной информации рабочих групп
            new Permission{
                        Id = 17,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Workgroup,
                        ActionTypeNum = (int?)PermissionsActionEnum.DeepView,
                        IsSystem = true,
                        Name = "Просмотр учетных данных рабочих групп",
                        AllowedOnlyForOwner = true
                    },
            //Создание пользовательских рабочих групп
            new Permission{
                        Id = 18,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Workgroup,
                        ActionTypeNum = (int?)PermissionsActionEnum.Create,
                        IsSystem = true,
                        Name = "Создание рабочих групп",
                        AllowedOnlyForOwner = false
                    },
            //Обновление данных пользователя
            new Permission{
                        Id = 19,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Workgroup,
                        ActionTypeNum = (int?)PermissionsActionEnum.Update,
                        IsSystem = true,
                        Name = "Выдача рабочих групп пользователям",
                        AllowedOnlyForOwner = false
                    },
            //Редактирование рабочих групп
            new Permission{
                        Id = 20,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Workgroup,
                        ActionTypeNum = (int?)PermissionsActionEnum.Edit,
                        IsSystem = true,
                        Name = "Редактирование рабочих групп",
                        AllowedOnlyForOwner = true
                    },
            //Блокировка рабочих групп
            new Permission{
                        Id = 21,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Workgroup,
                        ActionTypeNum = (int?)PermissionsActionEnum.SoftDelete,
                        IsSystem = true,
                        Name = "Отключение рабочих групп",
                        AllowedOnlyForOwner = true
                    },
            //Удаление пользовательских аккаунтов
            new Permission{
                        Id = 22,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Workgroup,
                        ActionTypeNum = (int?)PermissionsActionEnum.Delete,
                        IsSystem = true,
                        Name = "Удаление рабочих групп",
                        AllowedOnlyForOwner = true
                    },
            //Просмотр пермиссий
            new Permission{
                        Id = 23,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Permission,
                        ActionTypeNum = (int?)PermissionsActionEnum.View,
                        IsSystem = true,
                        Name = "Просмотр общедоступных пермиссий",
                        AllowedOnlyForOwner = false
                    },
            //Просмотр полной информации пермиссий
            new Permission{
                        Id = 24,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Permission,
                        ActionTypeNum = (int?)PermissionsActionEnum.DeepView,
                        IsSystem = true,
                        Name = "Просмотр пермиссий",
                        AllowedOnlyForOwner = true
                    },
            //Создание пермиссий
            new Permission{
                        Id = 25,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Permission,
                        ActionTypeNum = (int?)PermissionsActionEnum.Create,
                        IsSystem = true,
                        Name = "Создание пермиссий",
                        AllowedOnlyForOwner = false
                    },
            //Обновление данных ролям и рабочим группам
            new Permission{
                        Id = 26,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Permission,
                        ActionTypeNum = (int?)PermissionsActionEnum.Update,
                        IsSystem = true,
                        Name = "Выдача пермиссий ролям и рабочим группам",
                        AllowedOnlyForOwner = false
                    },
            //Редактирование пермиссий
            new Permission{
                        Id = 27,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Permission,
                        ActionTypeNum = (int?)PermissionsActionEnum.Edit,
                        IsSystem = true,
                        Name = "Редактирование пермиссий",
                        AllowedOnlyForOwner = true
                    },
            //Блокировка пермиссий
            new Permission{
                        Id = 28,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Permission,
                        ActionTypeNum = (int?)PermissionsActionEnum.SoftDelete,
                        IsSystem = true,
                        Name = "Отключение пермиссий",
                        AllowedOnlyForOwner = true
                    },
            //Удаление пермиссий
            new Permission{
                        Id = 29,
                        CreateDate = defaultDateTime,
                        LastModificationDate = defaultDateTime,
                        OwnerId = 1,
                        IsRemoved = false,
                        EntityTypeNum = (int?)EntityTypeEnum.Permission,
                        ActionTypeNum = (int?)PermissionsActionEnum.Delete,
                        IsSystem = true,
                        Name = "Удаление пермиссий",
                        AllowedOnlyForOwner = true
                    }
        };
    }
}

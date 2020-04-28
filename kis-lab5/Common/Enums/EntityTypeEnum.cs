using System.ComponentModel;

namespace Common.Enums
{
    /// <summary>
    /// Перечисление сущностей системы
    /// </summary>
    public enum EntityTypeEnum
    {
        /// <summary>
        /// Система
        /// </summary>
        [Description("Система")]
        System = int.MaxValue,

        /// <summary>
        /// Пользователь (медработник)
        /// </summary>
        [Description("Пользователи")]
        User = 0,

        /// <summary>
        /// Роль
        /// </summary>
        [Description("Роли")]
        Role = 1,

        /// <summary>
        /// Рабочая группа
        /// </summary>
        [Description("Рабочие группы")]
        Workgroup = 2,

        /// <summary>
        /// Привелегия/Разрешение
        /// </summary>
        [Description("Привелегии")]
        Permission = 3,

        /// <summary>
        /// Пациент
        /// </summary>
        [Description("Пациенты")]
        Patient = 4,

        /// <summary>
        /// История болезни.
        /// </summary>
        [Description("История болезни")]
        MedicalHistory = 5
    }
}
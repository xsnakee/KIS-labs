namespace Common.Resources.Messages
{
    /// <summary>
    /// Шаблонные сообщения системы
    /// TODO: перенести в ресурсы
    /// </summary>
    public static class Messages
    {
        #region Exceptions
        // Exception template:
        // public const string Exception_
        public const string Exception_Default = "Произошла ошибка. При необходимости обратитесь к администратору.";
        public const string Exception_SignInFail = "Логин пользователя или пароль введены не верно.";
        public const string Exception_Unauthorized = "Вы не авторизованы.";
        public const string Exception_PermissionsMissing = "У вас недостаточно прав на совершение данных действий.";
        public const string Exception_IncorrectData = "Данные заполненны неверно или отсутствуют.";
        public const string Exception_EntityNotFoundTemplate = "Сущность {0} с идентификатором {1} не найдена.";

        public const string Exception_EntityAlreadyExist_Templete = "{0} уже существует.";
        #endregion

        #region Validation
        // Validation template:
        // public const string Validation_
        #endregion

        #region Information
        public const string Information_LoginSuccess = "Вход в систему выполнен успешно.";
        public const string Information_ActionSuccess = "Действие выполнено успешно.";
        public const string Information_CreateSuccess_Template = "{0} создан(а) успешно.";
        public const string Information_SaveSuccess = "Данные успешно сохранены.";
        #endregion

        #region Entities
        public const string Entity_User = "Пользователь";
        public const string Entity_Role = "Роль";
        public const string Entity_Workgroup = "Рабочая группа";
        public const string Entity_Permission = "Разрешение";
        public const string Entity_Patient = "Пациент";
        public const string Entity_MedicalHistory = "История болезни";

        #endregion
    }
}

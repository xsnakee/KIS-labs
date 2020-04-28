using Microsoft.AspNetCore.Identity;

namespace UMIS.DAL.DomainAuth
{
    /// <summary>
    /// Кастомзированные шаблоны ошибок для Identity
    /// </summary>
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError() { return new IdentityError { Code = "Ошибка", Description = $"Произошла неизвестная ошибка." }; }
        public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = "Ошибка параллелизма", Description = "Ошибка параллелизма, объект был изменен." }; }
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = "Несоответствие пароля", Description = "Неверный пароль." }; }
        public override IdentityError InvalidToken() { return new IdentityError { Code = nameof(InvalidToken), Description = "Неверный токен." }; }
        public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = "Логин занят", Description = "Пользователь с таким логином уже существует." }; }
        public override IdentityError InvalidUserName(string userName) { return new IdentityError { Code = "Формат имени", Description = $"Имя пользователя - {userName} должно состоять из цифр и латинских букв." }; }
        public override IdentityError InvalidEmail(string email) { return new IdentityError { Code = "Формат email", Description = $"Email - {email} имеет не ферный формат." }; }
        public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = "Дублирование", Description = $"Логин -{userName} уже используется." }; }
        public override IdentityError DuplicateEmail(string email) { return new IdentityError { Code = "Дублирование", Description = $"Email - {email} уже используется." }; }
        public override IdentityError InvalidRoleName(string role) { return new IdentityError { Code = "Несоответствие роли", Description = $"Роль - {role} имеет не верный формат." }; }
        public override IdentityError DuplicateRoleName(string role) { return new IdentityError { Code = "Дублирование", Description = $"Роль - {role} уже используется." }; }
        public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = "Пароль", Description = "У пользователя уже установлен пароль." }; }
        public override IdentityError UserLockoutNotEnabled() { return new IdentityError { Code = "Отсутствие блокировки", Description = "Блокировка не включена для этого пользователя." }; }
        public override IdentityError UserAlreadyInRole(string role) { return new IdentityError { Code = "Дублирование", Description = $"Пользователь имеет данную роль '{role}'." }; }
        public override IdentityError UserNotInRole(string role) { return new IdentityError { Code = "Отсутствие роли", Description = $"Пользователь не имеет роли '{role}'." }; }
        public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = "Формат пароля", Description = $"Пароль должны содержать не менее {length} символов." }; }
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = "Формат пароля", Description = "Пароли должны содержать хотя бы один не специальный символ." }; }
        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = "Формат пароля", Description = "Пароли должны содержать хотя бы одну цифру ('0'-'9')." }; }
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = "Формат пароля", Description = "Пароли должны содержать хотя бы одну строчную букву ('a'-'z')." }; }
        public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = "Формат пароля", Description = "Пароли должны содержать хотя бы одну прописную букву('A'-'Z')." }; }
    }
}

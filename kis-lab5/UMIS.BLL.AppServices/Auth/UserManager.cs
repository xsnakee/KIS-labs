using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions;
using Common.Models.Filters;
using Common.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using UMIS.BLL.AppServices._Base;
using UMIS.BLL.AppServices.Helpers;
using UMIS.BLL.Contracts.Models.Auth;
using UMIS.BLL.Contracts.ServicesAbstraction;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth;
using IdentityUserManager = Microsoft.AspNetCore.Identity.UserManager<UMIS.DAL.Domain.Contracts.Models.Auth.User>;

namespace UMIS.BLL.AppServices.Auth
{
    public class UserManager : BaseManager, IUserManager
    {
        protected readonly IdentityUserManager _identityUserManager;
        protected readonly IUserRepository _userRepository;

        public UserManager(IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            IdentityUserManager identityUserManager,
            IUserRepository userRepository)
            : base(httpContextAccessor, mapper)
        {
            _identityUserManager = identityUserManager;
            _userRepository = userRepository;
        }

        public async Task<int> RegisterUser(UserRegistrationDto userDto)
        {
            User domainUser = Mapper.Map<User>(userDto);
            domainUser.OwnerId = UserId;
            IdentityResult result = await _identityUserManager
                .CreateAsync(domainUser, userDto.Password);

            if (!result.Succeeded)
            {
                IValidationResult validation = new ValidationResult();

                foreach (IdentityError error in result.Errors)
                {
                    validation.AddError(error.Code, error.Description);
                }

                throw new ValidationException(validation);
            }

            User userInfo = await _identityUserManager.FindByEmailAsync(userDto.Email);

            return userInfo.Id;
        }

        /// <summary>
        /// Добавить пользователя к роли в рабочей группе
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="roleWorkgroupId">Идентификатор роли в рабочей группе</param>
        public async Task AddUserToRoleWorkgroup(int userId, int roleWorkgroupId)
        {
            await _userRepository
                .AddUserToRoleAndWorkgroupAsync(userId, roleWorkgroupId);
        }

        /// <summary>
        /// Получить список пользователей для просмотра
        /// </summary>
        /// <param name="filter">Модель фильтра</param>
        /// <returns>Постраничный результат</returns>
        public async Task<PaginationResult<UserAuthInfoDto>> GetUsersAuthDataByFilterAsync(BaseFilter filter)
        {
            PaginationResult<User> result = await _userRepository
                .GetUsersAuthDataByFilterAsync(filter);

            return result.Convert<User, UserAuthInfoDto>(Mapper);
        }

        /// <inheritdoc />
        public async Task<bool> UserSoftDeleteAsync(int id)
        {
            return await _userRepository.DeleteToggleMarkAsync(id, delete: true);
        }
    }
}

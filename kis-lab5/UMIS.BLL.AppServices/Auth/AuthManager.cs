using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions;
using Common.Models.Results;
using Common.Resources.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TokenAuthentication;
using UMIS.BLL.AppServices._Base;
using UMIS.BLL.Contracts.Models.Auth;
using UMIS.BLL.Contracts.ServicesAbstraction;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth;

namespace UMIS.BLL.AppServices
{
    /// <summary>
    /// Менеджер по работе с авторизацией
    /// </summary>
    public class AuthManager : BaseManager, IAuthManager
    {
        protected readonly IUserRepository UserRepository;
        protected readonly IPermissionRepository PermissionRepository;
        protected readonly SignInManager<User> SignInManager;
        protected readonly ITokenService TokenService;

        public AuthManager(IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            IUserRepository userRpository,
            IPermissionRepository permissionRepository,
            SignInManager<User> signInManager,
            ITokenService tokenService)
            : base(httpContextAccessor, mapper)
        {
            UserRepository = userRpository;
            PermissionRepository = permissionRepository;
            SignInManager = signInManager;
            TokenService = tokenService;
        }

        /// <summary>
        /// Валидация пользователя и выдача токена
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns>JWT Token</returns>
        public async Task<string> LoginAsync(UserLoginDto loginDto)
        {
            SignInResult signInResult = await SignInManager
                .PasswordSignInAsync(loginDto.Login, loginDto.Password, loginDto.RememberMe, false);

            if (!signInResult.Succeeded)
            {
                throw new CustomException(Messages.Exception_SignInFail, statusCode: HttpStatusCode.Unauthorized);
            }

            User user = await UserRepository.GetUserByNameWithRelatedDataAsync(loginDto.Login);
            List<int> userPermissionsIds = (await PermissionRepository
                .GetPermissionsByUserIdAsync(user.Id))
                ?.Select(x => x.Id)
                .ToList();

            return TokenService.GenerateToken(user, userPermissionsIds);
        }

        /// <summary>
        /// Метод получения данных пользователя из контекста запроса
        /// </summary>
        /// <returns>Информация о пользователе</returns>
        public async Task<UserAuthInfoDto> GetCurrentUseInfoAsync()
        {
            if (!HttpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                throw new UnauthorizedException(Messages.Exception_Unauthorized);
            }

            Int32.TryParse(HttpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                    .Value,
                out int currentUserId);
            User user = await UserRepository.GetAsync(currentUserId);
            List<Permission> userPermissions = await PermissionRepository
                .GetPermissionsByUserIdAsync(user.Id);
            UserAuthInfoDto userDto = Mapper.Map<UserAuthInfoDto>(user);
            userDto.Permissions = Mapper.Map<List<PermissionDto>>(userPermissions);

            return userDto;
        }

        /// <summary>
        /// Проверка пермиссий текщуего пользователя на соответствие
        /// </summary>
        /// <param name="permissions">Список пермиссий</param>
        public Task<bool> CheckCurrentUserPermissionsAsync(params int[] permissionIds)
        {
            ValidationResult validation = new ValidationResult();

            if (UserPermissions.Contains(1)) // AdminPemission
            {
                return Task.FromResult(true);
            }

            foreach (int permission in permissionIds)
            {
                if (!UserPermissions.Contains(permission))
                {
                    validation.AddError(Messages.Exception_PermissionsMissing,
                        $"{Messages.Exception_PermissionsMissing} Id - {permission}");
                }
            }

            if (validation.IsFailed)
            {
                throw new ValidationException(validation);
            }

            return Task.FromResult(true);
        }
    }
}

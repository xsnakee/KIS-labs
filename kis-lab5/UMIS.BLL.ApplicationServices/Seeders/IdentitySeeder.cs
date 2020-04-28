using System;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Identity;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth;
using UMIS.DbSeed.Models;

namespace UMIS.DbSeed.Seeders
{
    /// <summary>
    /// Сервис заполняющий базу данных системными пользователями и ролями
    /// </summary>
    public class IdentitySeeder
    {
        public IdentitySeeder(UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IUserRepository userRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepository = userRepository;
        }

        private UserManager<User> _userManager { get; set; }
        private RoleManager<Role> _roleManager { get; set; }
        private IUserRepository _userRepository { get; set; }

        public async Task SeedSystemUsersAsync()
        {
            foreach (SystemUser user in SystemUsersForSeed)
            {
                IdentityResult result = null;

                User domainUser = await _userManager.FindByNameAsync(user.UserName);
                if (domainUser == null)
                {
                    domainUser = new User
                    {
                        Email = user.Email,
                        UserName = user.UserName,
                        IsSystem = true,
                        OwnerId = 1
                    };
                    result = await _userManager.CreateAsync(domainUser, user.Password);
                }
                else
                {
                    string token = await _userManager.GeneratePasswordResetTokenAsync(domainUser);
                    await _userManager.ResetPasswordAsync(domainUser, "", user.Password);
                    domainUser.Email = user.Email;
                    domainUser.IsSystem = true;
                    domainUser.OwnerId = 1;
                    domainUser.UserName = user.UserName;
                    result = await _userManager.UpdateAsync(domainUser);
                }

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(domainUser, user.Role);
                }
            }
        }

        public async Task SeedSystemRolesAsync()
        {
            foreach (SystemRole role in SystemRolesForSeed)
            {
                Role domainRole = await _roleManager.FindByIdAsync(role.Id.ToString());
                if (domainRole == null)
                {
                    domainRole = new Role
                    {
                        Name = role.Name,
                        CreateDate = DateTime.MinValue,
                        IsSystem = true,
                        OwnerId = 1
                    };
                    await _roleManager.CreateAsync(domainRole);
                }
            }
        }

        public async Task SeedUserWorkgroupRoles()
        {
            foreach (UserToRoleWorkgroup rw in UserRoleWorkgroupsForSeed)
            {
                bool isExist = await _userRepository
                    .IsExistUserToRoleAndWorkgroupAsync(rw.UserId, rw.RoleToWorkgroupId);

                if (!isExist)
                {
                    await _userRepository
                        .AddUserToRoleAndWorkgroupAsync(rw.UserId, rw.RoleToWorkgroupId);
                }
            }
        }

        /// <summary>
        /// Системные роли
        /// </summary>
        public static SystemRole[] SystemRolesForSeed
        {
            get
            {
                SystemRole adminRole = new SystemRole
                {
                    Id = CommonConfigurator.GetAppSettingsValue("SystemSeed:Admin:RoleId", 1),
                    Name = CommonConfigurator.GetAppSettingsValue("SystemSeed:Admin:Role", "Администратор")
                };
                SystemRole chiefDoctorRole = new SystemRole
                {
                    Id = CommonConfigurator.GetAppSettingsValue("SystemSeed:Admin:RoleId", 2),
                    Name = CommonConfigurator.GetAppSettingsValue("SystemSeed:ChiefDoctor:Role", "Главный врач")
                };

                return new SystemRole[]
                {
                    adminRole,
                    chiefDoctorRole
                };
            }
        }

        /// <summary>
        /// Системные пользователи
        /// </summary>
        public static SystemUser[] SystemUsersForSeed
        {
            get
            {
                string prefix = CommonConfigurator.GetAppSettingsValue("SystemSeed:Prefix", "");
                SystemUser admin = new SystemUser
                {
                    Email = CommonConfigurator.GetAppSettingsValue("SystemSeed:Admin:Email", "admin@gmail.com"),
                    UserName = $"{prefix}{CommonConfigurator.GetAppSettingsValue("SystemSeed:Admin:UserName", "UmisAdmin")}",
                    Password = $"{prefix}{CommonConfigurator.GetAppSettingsValue("SystemSeed:Admin:Password", "UmisAdmin123")}",
                    Role = CommonConfigurator.GetAppSettingsValue("SystemSeed:Admin:Role", "Admin")
                };
                SystemUser chiefDoctor = new SystemUser
                {
                    Email = CommonConfigurator.GetAppSettingsValue("SystemSeed:ChiefDoctor:Email", "ChiefDoctor@gmail.com"),
                    UserName = $"{prefix}{CommonConfigurator.GetAppSettingsValue("SystemSeed:ChiefDoctor:UserName", "UmisChiefDoctor")}",
                    Password = $"{prefix}{CommonConfigurator.GetAppSettingsValue("SystemSeed:ChiefDoctor:Password", "UmisChiefDoctor123")}",
                    Role = CommonConfigurator.GetAppSettingsValue("SystemSeed:ChiefDoctor:Role", "ChiefDoctor")
                };

                return new SystemUser[]
                {
                admin,
                chiefDoctor
                };
            }
        }

        /// <summary>
        /// Связь пользователей с рабочими группами
        /// </summary>
        public static UserToRoleWorkgroup[] UserRoleWorkgroupsForSeed
        {
            get
            {
                return new UserToRoleWorkgroup[]
                {
                    new UserToRoleWorkgroup
                    {
                        UserId = 1,
                        RoleToWorkgroupId = 1
                    },
                    new UserToRoleWorkgroup
                    {
                        UserId = 2,
                        RoleToWorkgroupId = 2
                    }
                };
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using UMIS.BLL.AppServices;
using UMIS.BLL.AppServices.Auth;
using UMIS.BLL.AppServices.Automapper.Profiles;
using UMIS.BLL.AppServices.Common;
using UMIS.BLL.AppServices.Handlers;
using UMIS.BLL.Contracts.Handlers;
using UMIS.BLL.Contracts.ServicesAbstraction;
using UMIS.BLL.Contracts.ServicesAbstraction.Common;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Common;
using UMIS.DAL.Repositories.Auth;
using UMIS.DAL.Repositories.Common;
using UmisUserManager = UMIS.BLL.AppServices.Auth.UserManager;

namespace StartUpExtensions
{
    public static class DependencyInjector
    {
        /// <summary>
        /// BLL ComponentRegistrar
        /// </summary>
        public static IServiceCollection ResolveServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Auth BLL
            services.AddScoped<UserManager<User>>();
            services.AddScoped<RoleManager<Role>>();
            services.AddScoped<SignInManager<User>>();
            services.AddScoped<IUserManager, UmisUserManager>();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IPermissionManager, PermissionManager>();
            services.AddScoped<IWorkgroupManager, WorkgroupManager>();
            services.AddScoped<IRoleManager, RoleManager>();
            services.AddScoped<IPermissionManager, PermissionManager>();
            services.AddScoped<IAttributeHandler, AttributeHandler>();
            services.AddScoped<IExceptionHandler, ExceptionHandler>();

            //Common BLL

            services.AddScoped<IPatientManager, PatientManager>();
            services.AddScoped<IMedicalHistoryManager, MedicalHistoryManager>();

            return services;
        }

        /// <summary>
        /// DAL ComponentRegistrar
        /// </summary>
        public static IServiceCollection ResolveRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            //Auth DAL
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IWorkgroupRepository, WorkgroupRepository>();
            services.AddScoped<IRoleToWorkgroupRepository, RoleToWorkgroupRepository>();

            //Auth Common
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();

            return services;
        }

        /// <summary>
        /// SwaggerRegistrar
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ResolveSwagger(this IServiceCollection services, IConfiguration configuration)
        {

            List<Assembly> assemblyWithDocs = new List<Assembly>()
            {
                Assembly.GetEntryAssembly(),
                Assembly.GetAssembly(typeof(UMIS.BLL.Contracts.Models.Base.BaseDto)),
                Assembly.GetAssembly(typeof(Common.Models.Filters.BaseFilter))
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Please enter into field the word 'Bearer' following by space and JWT",
                        Name = "Authorization",
                        Type = "apiKey"
                    });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                    { "Bearer", Enumerable.Empty<string>() }});

                assemblyWithDocs.ForEach(x =>
                {
                    var xmlDocs = Path.Combine(Path.GetDirectoryName(x.Location), $"{x.GetName().Name}.xml");
                    c.IncludeXmlComments(xmlDocs, true);
                });
            });

            return services;
        }

        /// <summary>
        /// Инъекция зависимостей автомаппера
        /// </summary>
        public static IServiceCollection ResolveAutomapper(this IServiceCollection services)
        {
            Type[] MapperProfiles =
            {
                typeof(UmisAutomapperProfile),
            };

            services.AddAutoMapper(MapperProfiles);

            return services;
        }
    }
}
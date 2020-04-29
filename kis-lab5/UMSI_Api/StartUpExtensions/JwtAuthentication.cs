using System;
using System.Text;
using Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TokenAuthentication;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.DomainAuth;

namespace StartUpExtensions
{
    public static class JwtAuthentication
    {
        public static IServiceCollection ResolveJwtIdentityAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = true; // Default
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequiredLength = 6; //Default
                options.Password.RequireLowercase = true; // Default
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true; // Default

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Default
                options.Lockout.MaxFailedAccessAttempts = 3;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_@";
                options.User.RequireUniqueEmail = false;
            })
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AuthDbContext>();

            services
                .AddAuthentication(opts =>
                {
                    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = Constants.JwtIssuer,
                        ValidAudience = Constants.JwtAudience,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.JwtSecret))
                    };
                });

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }

    }
}

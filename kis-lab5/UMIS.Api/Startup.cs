using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StartUpExtensions;
using UMIS.Api.Filters;

namespace UMIS.Api
{
    /// <summary>
    /// StartUp
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// StarUp
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Cors policy name
        /// </summary>
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        /// <summary>
        /// Configure and add services
        /// </summary>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var temp = Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
            services.AddCors(opt =>
                opt.AddPolicy(MyAllowSpecificOrigins, h => h
                    .WithOrigins(Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>())
                    .AllowAnyHeader()
                    .AllowAnyMethod()
            ));
            services.ResolveDatabases(Configuration);
            services.ResolveSwagger(Configuration);
            services.ResolveServices(Configuration);
            services.ResolveRepositories(Configuration);
            services.ResolveAutomapper();
            services.ResolveJwtIdentityAuth(Configuration);
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(PermissionHandleFilter));
                options.Filters.Add(typeof(ExceptionToVoidResultFilter));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        /// <summary>
        /// Configure and run components
        /// </summary>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UMIS API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedHost | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();
            app.UseCors(MyAllowSpecificOrigins);
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

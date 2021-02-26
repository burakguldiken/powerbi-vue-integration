using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphClient.Extensions
{
    public static class BuilderExtension
    {
        public static void Configure(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(x => x
                           .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            app.UseSwagger()

            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/PowerBi/swagger.json", "PowerBi");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }

        #region SwaggerConfiguration
        public static void SwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("PowerBi", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AzureAD PowerBi",
                    Description = "Azure Active Directory PowerBi v1",
                });
            });
        }
        #endregion

        #region Header Configuration
        public static void HeaderConfiguration(this IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
        }
        #endregion

        #region AddMiddleware
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            services.AddHttpContextAccessor();
            services.AddMemoryCache();
        }
        #endregion
    }
}

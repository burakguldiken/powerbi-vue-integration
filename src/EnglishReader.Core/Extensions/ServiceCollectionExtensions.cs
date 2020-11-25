using System;
using System.Collections.Generic;
using System.Text;
using EnglishReader.Core.Utilities.Appsettings;
using EnglishReader.Core.Utilities.Configuration;
using EnglishReader.Core.Utilities.Security.Token;
using EnglishReader.Core.Utilities.Security.Token.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishReader.Core.Extensions
{
    /// <summary>
    /// ServiceCollectionExtensions class for core dependencies
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Extension method for IServiceCollection
        /// </summary>
        /// <param name="services"></param>
        public static void AddCoreDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ITokenService, JwtTokenService>();

            services.AddSingleton<IConfigurationService, ConfigurationService>();
            services.AddSingleton<IAppsettingsContext, AppsettingsContext>();
        }
    }
}

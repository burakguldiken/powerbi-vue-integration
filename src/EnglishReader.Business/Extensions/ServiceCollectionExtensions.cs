using System;
using System.Collections.Generic;
using System.Text;
using EnglishReader.Business.Abstract;
using EnglishReader.Business.Concrete;
using EnglishReader.DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishReader.Business.Extensions
{
    /// <summary>
    /// ServiceCollectionExtensions class for business dependencies
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Extension method for IServiceCollection
        /// </summary>
        /// <param name="services"></param>
        public static void AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();


            services.AddDataAccessDependencies();
        }
    }
}

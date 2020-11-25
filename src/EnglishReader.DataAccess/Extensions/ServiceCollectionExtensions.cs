using System;
using System.Collections.Generic;
using System.Text;
using EnglishReader.DataAccess.Abstract;
using EnglishReader.DataAccess.EntityFramework.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishReader.DataAccess.Extensions
{
    /// <summary>
    /// ServiceCollectionExtensions class for data access dependencies
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Extension method for IServiceCollection
        /// </summary>
        /// <param name="services"></param>
        public static void AddDataAccessDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserDal, EfUserDal>();
        }
    }
}

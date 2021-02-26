using BusinessLogic.IServices;
using BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphClient.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            //Add Dependency Injections Here.
            services.AddScoped<IPowerBiService, PowerBiService>();
        }
    }
}

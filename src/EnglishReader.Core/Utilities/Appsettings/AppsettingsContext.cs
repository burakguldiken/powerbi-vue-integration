using System;
using System.Collections.Generic;
using System.Text;
using EnglishReader.Core.Utilities.Configuration;

namespace EnglishReader.Core.Utilities.Appsettings
{
    public class AppsettingsContext : IAppsettingsContext
    {
        public string RabbitMQHost { get; }
        public string RabbitMQPort { get; }
        public string RabbitMQUsername { get; }
        public string RabbitMQPassword { get; }

        public string MySQLHost { get; }
        public string MySQLPort { get; }
        public string MySQLUsername { get; }
        public string MySQLPassword { get; }


        public string RedisHost { get; }
        public string RedisPort { get; }
        public string RedisUsername { get; }
        public string RedisPassword { get; }



        public AppsettingsContext(IConfigurationService configurationService)
        {
            RabbitMQHost = configurationService.Configuration["RabbitMQ:Host"].ToString();
            RabbitMQPort = configurationService.Configuration["RabbitMQ:Port"].ToString();
            RabbitMQUsername = configurationService.Configuration["RabbitMQ:Username"].ToString();
            RabbitMQPassword = configurationService.Configuration["RabbitMQ:Password"].ToString();

            MySQLHost = configurationService.Configuration["MySQL:Host"].ToString();
            MySQLPort = configurationService.Configuration["MySQL:Port"].ToString();
            MySQLUsername = configurationService.Configuration["MySQL:Username"].ToString();
            MySQLPassword = configurationService.Configuration["MySQL:Password"].ToString();

            RedisHost = configurationService.Configuration["Redis:Host"].ToString();
            RedisPort = configurationService.Configuration["Redis:Port"].ToString();
            RedisUsername = configurationService.Configuration["Redis:Username"].ToString();
            RedisPassword = configurationService.Configuration["Redis:Password"].ToString();
        }
    }
}

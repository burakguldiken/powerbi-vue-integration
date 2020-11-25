using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishReader.Core.Utilities.Appsettings
{
    public interface IAppsettingsContext
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
    }
}

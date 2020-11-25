using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace EnglishReader.Core.Utilities.Configuration
{
    /// <summary>
    /// Configuration service implementation
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {
        private IConfiguration _configuration;

        private static string _environmentVariableValue = "";
        private static string _environmentVariableKey = "ENGLISH_READER_ENVIRONMENT";


        public IConfiguration Configuration => _configuration;

        public bool IsProduction => _environmentVariableValue == "production";
        public bool IsStaging => _environmentVariableValue == "staging";
        public bool IsDevelopment => _environmentVariableValue == "development";

        public ConfigurationService()
        {
            SetConfiguration();
        }

        private void SetConfiguration()
        {
            if (Debugger.IsAttached)
            {
                _environmentVariableValue = Environment.GetEnvironmentVariable(_environmentVariableKey);
            }
            else
            {
                _environmentVariableValue = Environment.GetEnvironmentVariable(_environmentVariableKey, EnvironmentVariableTarget.Process);
            }

            if (String.IsNullOrEmpty(_environmentVariableValue))
            {
                throw new Exception($"{_environmentVariableKey} can not be null!");
            }

            _environmentVariableKey = _environmentVariableValue.ToLower();


            _configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile($"appsettings.{_environmentVariableValue}.json",true,false)
                .Build();
        }
    }
}

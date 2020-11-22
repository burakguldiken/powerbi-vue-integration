using Microsoft.Extensions.Configuration;

namespace EnglishReader.Core.Utilities.Configuration
{
    /// <summary>
    /// Configuration service
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Check env. area is production
        /// </summary>
        public bool IsProduction { get; }
        /// <summary>
        /// Check env. area is staging
        /// </summary>
        public bool IsStaging { get; }
        /// <summary>
        /// Check env. area is development
        /// </summary>
        public bool IsDevelopment { get; }
    }
}

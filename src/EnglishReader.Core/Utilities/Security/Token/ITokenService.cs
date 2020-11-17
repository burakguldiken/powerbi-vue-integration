using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishReader.Core.Utilities.Security.Token
{
    /// <summary>
    /// Token service for security.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Generate method.
        /// </summary>
        /// <param name="userId">Unique user id.</param>
        /// <returns></returns>
        (DateTime expiredDate, string token) GenerateToken(long userId);
    }
}

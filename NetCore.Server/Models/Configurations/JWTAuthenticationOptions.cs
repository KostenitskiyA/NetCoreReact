using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NetCore.Server.Models.Configurations
{
    /// <summary>
    /// Настройки JWT
    /// </summary>
    public class JWTAuthenticationOptions
    {
        /// <summary>
        /// Издатель
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Слушатель
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Секрет
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Срок жизни токена
        /// </summary>
        public int TokenLifetime { get; set; }

        /// <summary>
        /// Получить ключ безопасности
        /// </summary>
        /// <returns></returns>
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}

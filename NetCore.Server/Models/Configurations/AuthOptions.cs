using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NetCore.Server.Models.Configurations
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TokenLifetime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}

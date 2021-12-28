using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Common.MagicStrings
{
    public class ConfigurationKeys
    {
        public static string JWT_TokenSecret = "JWT:TokenSecret";
        public static string JWT_ValidIssuer = "JWT:ValidIssuer";
        public static string JWT_ValidAudience = "JWT:ValidAudience";
        public static string JWT_Expiration = "JWT:Expiration";
        public static string Hash_iterations = "Iterations";
    }
}

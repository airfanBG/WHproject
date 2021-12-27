using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Infrastructure.Vmodels;

namespace Utils.Infrastructure.Interfaces.Services
{
    public interface IuserIdentityService
    {
        public Task<JwtSecurityToken> LoginAsync(LoginModel model);
        public Task<int> RegisterAsync(RegisterModel model);
    }
}

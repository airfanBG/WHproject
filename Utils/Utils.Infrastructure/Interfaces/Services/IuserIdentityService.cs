using System.IdentityModel.Tokens.Jwt;
using Utils.Infrastructure.Vmodels;

namespace Utils.Infrastructure.Interfaces.Services
{
    public interface IuserIdentityService
    {
        public Task<string> LoginAsync(LoginModel model);
        public Task<int> RegisterAsync(RegisterModel model);
    }
}

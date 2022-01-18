using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Utils.Infrastructure.Vmodels;

namespace Utils.Infrastructure.Interfaces.Services
{
    public interface IuserIdentityService
    {
        public Task<string> LoginAsync(LoginModel model, bool isCustomer);
        public Task<int> RegisterAsync(RegisterModel model, bool isCustomer);
    }
}

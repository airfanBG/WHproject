using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Utils.Common.MagicStrings;
using Utils.Common.Security;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Infrastructure.Vmodels;

namespace Utils.Services.DataServices.Identity
{
    internal class IdentityService : IuserIdentityService
    {

        public IdentityService(IConfiguration configuration, IDatabaseService databaseService)
        {
            Configuration = configuration;
            DatabaseService = databaseService;
        }

        private IConfiguration Configuration { get; }
        private IDatabaseService DatabaseService { get; }

        public async Task<JwtSecurityToken> LoginAsync(LoginModel model)
        {
            var user = await DatabaseService.Context.Set<EmailAddress>().FirstOrDefaultAsync(x => x.Email == model.Email);
            if (user == null) return new JwtSecurityToken();
            else
            {
                var userPass=await DatabaseService.Context.Set<Password>().FirstOrDefaultAsync(x=>x.BusinessEntityId==user.BusinessEntityId);
                var verify = SecurePasswordHasher.Verify(model.Password, userPass.PasswordHash);
                if (!verify) return new JwtSecurityToken();
                else
                {
                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[ConfigurationKeys.JWT_TokenSecret]));

                    var token = new JwtSecurityToken(
                        issuer: Configuration[ConfigurationKeys.JWT_ValidIssuer],
                        audience: Configuration[ConfigurationKeys.JWT_ValidAudience],
                        expires: DateTime.Now.AddHours(double.Parse(Configuration[ConfigurationKeys.JWT_Expiration])),
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );
                    return token;
                }
            }
        }

        public async Task<int> RegisterAsync(RegisterModel model)
        {

            var userExists = await DatabaseService.Context.Set<EmailAddress>().FirstOrDefaultAsync(x => x.Email == model.Email);


            if (userExists != null)
            {
                Password password = await DatabaseService.Context.Set<Password>().FirstOrDefaultAsync(x => x.BusinessEntityId == userExists.BusinessEntityId);
                var hashed = SecurePasswordHasher.Hash(model.Password,int.Parse(Configuration[ConfigurationKeys.Hash_iterations]));
                password.PasswordHash = hashed;

                DatabaseService.Context.Set<Password>().Update(password);
                await DatabaseService.Context.SaveChangesAsync();
                return 1;
            }
            return 0;

        }
        //private async Task<Person> GetPersonId()
        //{

        //}
    }
}

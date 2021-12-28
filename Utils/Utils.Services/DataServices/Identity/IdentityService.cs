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
    public class IdentityService : IuserIdentityService
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
            try
            {

                await using (DatabaseService)
                {
                    var user = DatabaseService.Context.Set<EmailAddress>().FirstOrDefault(x => x.Email == model.Email);
                    if (user == null) return new JwtSecurityToken();
                    else
                    {
                        var userPass = DatabaseService.Context.Set<Password>().FirstOrDefault(x => x.BusinessEntityId == user.BusinessEntityId);
                        var verify = SecurePasswordHasher.VerifyPassword(model.Password, userPass.PasswordHash, userPass.PasswordSalt);
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
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> RegisterAsync(RegisterModel model)
        {
            try
            {

               await using (DatabaseService)
                {
                    var userExists = DatabaseService.Context.Set<EmailAddress>().FirstOrDefault(x => x.Email == model.Email);


                    if (userExists != null)
                    {
                        Password password = DatabaseService.Context.Set<Password>().FirstOrDefault(x => x.BusinessEntityId == userExists.BusinessEntityId && x.isRegistered == false)!;

                        if (password == null)
                        {
                            return 0;
                        }

                        var hashed = SecurePasswordHasher.Hash(model.Password);
                        password.PasswordHash = hashed.Item1;
                        password.ModifiedDate = DateTime.UtcNow;
                        password.isRegistered = true;
                        password.PasswordSalt = hashed.Item2;
                       
                        DatabaseService.Context.Set<Password>().Update(password);
                        DatabaseService.Context.SaveChanges();
                        return 1;
                    }
                    return 0;
                }
                

            }
            catch (Exception)
            {

                throw;
            }

        }
        //private async Task<Person> GetPersonId()
        //{

        //}
    }
}

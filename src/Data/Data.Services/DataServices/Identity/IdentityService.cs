using Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<string> LoginAsync(LoginModel model)
        {
            try
            {

                await using (DatabaseService)
                {
                    var user = DatabaseService.Context.Set<Customer>().FirstOrDefault(x => x.EmailAddress == model.Email);
                    if (user == null) return "";
                    else
                    {
                        var verify = SecurePasswordHasher.VerifyPassword(model.Password, user.PasswordHash, user.PasswordSalt);
                        if (!verify) return "";
                        else
                        {
                            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[ConfigurationKeys.JWT_TokenSecret]));

                            var tokenHandler = new JwtSecurityTokenHandler();
                            Claim customerClaimId = null;
                           
                            var tokenDescriptor = new SecurityTokenDescriptor
                            {
                                Subject = new ClaimsIdentity(new Claim[]
                                {
                                    new Claim(ClaimTypes.Role, "Customer"),
                                    new Claim("email", model.Email),
                                    new Claim("userid", user.CustomerId.ToString()),
                                   
                                    customerClaimId ?? null!
                                }),

                                Expires = DateTime.UtcNow.AddMinutes(int.Parse(Configuration[ConfigurationKeys.JWT_Expiration])),
                                Issuer = Configuration[ConfigurationKeys.JWT_ValidIssuer],
                                Audience = Configuration[ConfigurationKeys.JWT_ValidAudience],
                                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                            };

                            var token = tokenHandler.CreateToken(tokenDescriptor);

                            return tokenHandler.WriteToken(token);
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
                    var userExists = DatabaseService.Context.Set<Customer>().FirstOrDefault(x => x.EmailAddress == model.Email && x.isTaken==false);
                   

                    if (userExists != null)
                    {
                        var hashed = SecurePasswordHasher.Hash(model.Password);
                        userExists.PasswordHash = hashed.Item1;
                        userExists.ModifiedDate = DateTime.UtcNow;
                        userExists.isTaken = true;
                   
                        userExists.PasswordSalt = hashed.Item2;
                     
                        DatabaseService.Context.Set<Customer>().Update(userExists);
                        
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

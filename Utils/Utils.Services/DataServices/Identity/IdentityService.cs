using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public async Task<string> LoginAsync(LoginModel model)
        {
            try
            {

                await using (DatabaseService)
                {
                    var user = DatabaseService.Context.Set<EmailAddress>().Include(x=>x.BusinessEntity).FirstOrDefault(x => x.Email == model.Email);
                    if (user == null) return "";
                    else
                    {
                        var userPass = DatabaseService.Context.Set<Password>().FirstOrDefault(x => x.BusinessEntityId == user.BusinessEntityId);
                        var verify = SecurePasswordHasher.VerifyPassword(model.Password, userPass.PasswordHash, userPass.PasswordSalt);
                        if (!verify) return "";
                        else
                        {
                            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[ConfigurationKeys.JWT_TokenSecret]));

                            var tokenHandler = new JwtSecurityTokenHandler();

                            var tokenDescriptor = new SecurityTokenDescriptor
                            {
                                Subject = new ClaimsIdentity(new Claim[]
                                {
                                    new Claim(ClaimTypes.Name, user.Name),
                                    new Claim(ClaimTypes.Role, user.BusinessEntity.PersonType),
                                    new Claim("Full_Name",String.Format($"{user.BusinessEntity.FirstName} {user.BusinessEntity.LastName}"))
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
                    var userExists = DatabaseService.Context.Set<EmailAddress>().FirstOrDefault(x => x.Email == model.Email);
                    var username= DatabaseService.Context.Set<EmailAddress>().FirstOrDefault(x => x.Name == model.Name);

                    if (userExists != null && username==null)
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
                        userExists.Name= model.Name;
                  
                        DatabaseService.Context.Set<EmailAddress>().Update(userExists);
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

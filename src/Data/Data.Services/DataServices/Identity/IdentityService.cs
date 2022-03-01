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

        public async Task<string> LoginAsync(LoginModel model, bool isCustomer)
        {
            try
            {
                if (model == null)
                {
                    return "";
                }
                await using (DatabaseService)
                {
                    if (isCustomer)
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
                    else
                    {
                        var user = DatabaseService.Context.Set<User>().FirstOrDefault(x => x.Email == model.Email);
                        if (user == null)return "";
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
                                    new Claim(ClaimTypes.Role, "Admin"),
                                    new Claim("email", model.Email),
                                    new Claim("userid", user.UserId.ToString()),
                                   
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

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> RegisterAsync(RegisterModel model, bool isCustomer)
        {
            try
            {
                if (model == null)
                {
                    return 0;
                }
                await using (DatabaseService)
                {
                    //This is when user register as customer and method executes check in db if email exists. 
                    if (isCustomer)
                    {
                        var userExists = DatabaseService.Context.Set<Customer>().FirstOrDefault(x => x.EmailAddress == model.Email && x.isTaken == false);


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
                    else
                    {
                        //This code register user of application
                        User user = DatabaseService.Context.Set<User>().FirstOrDefault(x => x.Email == model.Email);
                        if (user == null)
                        {
                            user = new User();
                            var hashed = SecurePasswordHasher.Hash(model.Password);
                            user.PasswordHash = hashed.Item1;
                            user.ModifiedDate = DateTime.UtcNow;
                            user.PasswordSalt = hashed.Item2;
                            user.Email=model.Email;

                            await DatabaseService.Context.Set<User>().AddAsync(user);
                            DatabaseService.Context.SaveChanges();
                            return 1;
                        }
                        return 0;
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Infrastructure.Vmodels;

namespace ClientSide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IuserIdentityService Service { get; }
        public ILogger<AuthController> Logger { get; }

        public AuthController(IuserIdentityService service, ILogger<AuthController> logger)
        {
            Service = service;
            Logger = logger;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result =await Service.RegisterAsync(model);
            if (result == 1)
            {
                Logger.LogInformation($"User {model.Email} is registered.");
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            var result = await Service.LoginAsync(model);
           
            if (result!=null)
            {
                var token = new JwtSecurityTokenHandler().ReadJwtToken(result);
                var claimEmail = token.Claims.First(c => c.Type == "email").Value;
                var claimId = token.Claims.First(c => c.Type == "userid").Value;
                var claimRole = token.Claims.First(c => c.Type == "role").Value;
                User.AddIdentity(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, claimEmail.Trim()), new Claim(ClaimTypes.Role,claimRole),new Claim("id",claimId)}));
                
                Logger.LogInformation("{UserName} {UserId}",claimEmail,claimId);
                return Ok(result);
            }
            return BadRequest();
        }

    }
}

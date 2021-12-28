using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Infrastructure.Vmodels;

namespace ClientSide.WebAPI.Controllers
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
                Logger.LogInformation($"User {model.Name} is registered.");
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
                var claim = token.Claims.First(c => c.Type == "unique_name").Value;
                User.AddIdentity(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, claim.Trim())}));
                
                Logger.LogInformation($"User {claim.Trim()} is logged.");
                return Ok(result);
            }
            return BadRequest();
        }

    }
}

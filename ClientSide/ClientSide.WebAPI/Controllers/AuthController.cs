using Microsoft.AspNetCore.Mvc;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Infrastructure.Vmodels;

namespace ClientSide.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IuserIdentityService Service { get; }

        public AuthController(IuserIdentityService service)
        {
            Service = service;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {

            var result =await Service.RegisterAsync(model);
            if (result == 1)
            {
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
                return Ok(result);
            }
            return BadRequest();
        }

    }
}

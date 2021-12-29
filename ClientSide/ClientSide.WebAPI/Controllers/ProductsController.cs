using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utils.Infrastructure.Interfaces.Services;

namespace ClientSide.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        public IBasicWarehouseService<Product> Service { get; }
        public ILogger<ProductsController> Logger { get; }

        public ProductsController(IBasicWarehouseService<Product> service, ILogger<ProductsController> logger)
        {
            Service = service;
            Logger = logger;
        }

   
        [HttpGet]
        [Route("all_products")]
        public async Task<IActionResult> GetAllProducts()
        {
            Logger.LogInformation($"User {User?.Identity?.Name} call all products action");
            return new JsonResult(await Service.GetAllAsync());
        }
        [HttpPost]
        [Route("add")]
        //[Authorize(Roles ="ЕМ")]
        public async Task<IActionResult> AddProduct([FromBody] Product model)
        {
            Logger.LogInformation($"User {User?.Identity?.Name} add product");
            var res = await Service.Add(model);
            if (res == 1)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

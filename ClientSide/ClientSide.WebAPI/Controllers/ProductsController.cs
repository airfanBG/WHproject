using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utils.Common.Extensions;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Infrastructure.Vmodels;

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
        [Route("all-products")]
        public async Task<IActionResult> GetAllProducts()
        {
            Logger.LogInformation($"User {User?.Identity?.Name} call all products action");
            var products = await Service.GetAllAsync();

            var productWIthCategory=products.Include(x=>x.ProductModel).ThenInclude(x=>x.ProductModelProductDescriptions).ThenInclude(x=>x.ProductDescription).Include(x=>x.ProductCategory).Select(x=>x.Product()).FirstOrDefault();
            return new JsonResult(productWIthCategory);
        }
        [HttpGet]
        [Route("product")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            Logger.LogInformation($"User {User?.Identity?.Name} call all products action");
            var products = await Service.GetAllAsync(x=>x.ProductId==productId);

            var productsWithCategory = products.Include(x => x.ProductModel).ThenInclude(x => x.ProductModelProductDescriptions).ThenInclude(x => x.ProductDescription).Include(x => x.ProductCategory).Select(x => x.Product()).ToListAsync();
            return new JsonResult(productsWithCategory);
        }

    }
}

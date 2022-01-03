using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Utils.Common.Extensions;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Infrastructure.Vmodels;

namespace ClientSide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
            Logger.LogInformation("{UserName} {UserId} Get all products {customerId}", User.FindFirst("email"), User.FindFirst("userid"));
            var products = await Task.Run(()=>Service.DatabaseService.Context.Set<Product>().Include(x=>x.ProductModel).ThenInclude(x=>x.ProductModelProductDescriptions).ThenInclude(x=>x.ProductDescription).Include(x=>x.ProductCategory).Select(x=>x.Product()).FirstOrDefault());
            return new JsonResult(Service.DatabaseService.Context.Set<Product>().ToList());
        }
        [HttpGet]
        [Route("product/{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            Logger.LogInformation("{UserName} {UserId} Get Product {productId}", User.FindFirst("email"), User.FindFirst("userid"), productId);
            var products = await Task.Run(() => Service.DatabaseService.Context.Set<Product>().Where(x=>x.ProductId==productId).Include(x => x.ProductModel).ThenInclude(x => x.ProductModelProductDescriptions).ThenInclude(x => x.ProductDescription).Include(x => x.ProductCategory).Select(x => x.Product()).ToListAsync());
            return new JsonResult(products);
        }

    }
}

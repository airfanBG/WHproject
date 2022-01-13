using Data.Infrastructure.Interfaces.Models;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        [Route("all-products/{culture}")]
        public async Task<IActionResult> GetAllProducts(string culture="en")
        {
           
            Logger.LogInformation("{Email} {UserId} Get all products", User.FindFirst("email"), User.FindFirst("userid"));
          var res=await Task.Run(() => Service.QuerySelector(predicate: null, selector: x => x.Product(), include: a => a.Include(o => o.ProductModel).ThenInclude(o => o.ProductModelProductDescriptions.Where(x=>x.Culture==culture)).ThenInclude(o => o.ProductDescription).Include(o => o.ProductCategory)));

            var json = JsonConvert.SerializeObject(res, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            return Ok(json);
        }
        [HttpGet]
        [Route("product/{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            Logger.LogInformation("{Email} {UserId} Get Product {productId}", User.FindFirst("email"), User.FindFirst("userid"), productId);

            var res=await Task.Run(()=> Service.QuerySelector(predicate: x => x.ProductId == productId, selector: z => z.Product(), include: a => a.Include(o => o.ProductModel).ThenInclude(o => o.ProductModelProductDescriptions).ThenInclude(o => o.ProductDescription).Include(o => o.ProductCategory)));

            var json = JsonConvert.SerializeObject(res, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            return Ok(json);
        }

    }
}

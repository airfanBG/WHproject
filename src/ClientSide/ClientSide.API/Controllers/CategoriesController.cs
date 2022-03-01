using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using Utils.Common.Extensions;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Infrastructure.Vmodels;

namespace ClientSide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class CategoriesController : ControllerBase
    {
        public IBasicWarehouseService<ProductCategory> Service { get; }

        public CategoriesController(IBasicWarehouseService<ProductCategory> service)
        {
            Service = service;
        }
        [HttpGet]
        [Route("all-categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await Task.Run(()=> Service.GetAllAsync().Result.Select(x=>x.Category()).ToList());

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            return Ok(categories);
        }
        [HttpGet]
        [Route("all-products-by-category")]
        public async Task<IActionResult> GetAllCategoriesWithProducts()
        {
            var categories = await Task.Run(() => Service.QuerySelector(selector: x=>x.CategoryWithProducts(),include: x=>x.Include(z=>z.Products),disableTracking:true).ToList());
          
            return Ok(categories);
        }
        [HttpGet]
        [Route("category-products/{categoryId}")]
        public async Task<IActionResult> GetCategoryProducts(int categoryId)
        {

            var categories =await Task.Run(()=> Service.QuerySelector(disableTracking:true,predicate: x => x.ProductCategoryId == categoryId,include: z => z.Include(a=>a.Products),selector: x => x.CategoryWithProducts()).FirstOrDefault());
           
            return Ok(categories);
        }

    }

}
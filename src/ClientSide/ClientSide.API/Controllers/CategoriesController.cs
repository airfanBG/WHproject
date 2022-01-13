using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Utils.Common.Extensions;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Infrastructure.Vmodels;

namespace ClientSide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
           
            return new JsonResult(categories);
        }
        [HttpGet]
        [Route("all-categories-products")]
        public async Task<IActionResult> GetAllCategoriesWithProducts()
        {
            var categories = await Task.Run(() => Service.QuerySelector(selector: x=>x.Category(),include: x=>x.Include(z=>z.Products),disableTracking:false).ToList());

            return new JsonResult(categories);
        }
        [HttpGet]
        [Route("category-products/{categoryId}")]
        public async Task<IActionResult> GetCategoryProducts(int categoryId)
        {

            var categories =await Task.Run(()=> Service.QuerySelector(predicate: x => x.ProductCategoryId == categoryId,include: z => z.Include(a=>a.Products),selector: x => x.CategoryWithProducts()).ToList());

            return new JsonResult(categories);
        }

    }

}
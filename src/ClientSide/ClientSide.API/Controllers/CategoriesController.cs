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
    //[Authorize]
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
            var categories = await Task.Run(() => Service.DatabaseService.Context.Set<ProductCategory>().Include(x => x.Products).Select(x => x.CategoryWithProducts()).ToList());

            return new JsonResult(categories);
        }
        [HttpGet]
        [Route("category-products/{categoryId}")]
        public async Task<IActionResult> GetCategoryProducts(int categoryId)
        {
            var categories = await Task.Run(() => Service.DatabaseService.Context.Set<ProductCategory>().Where(x=>x.ProductCategoryId==categoryId).Include(x => x.Products).Select(x => x.CategoryWithProducts()).ToList());

            return new JsonResult(categories);
        }
    }
}
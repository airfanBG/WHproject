using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utils.Infrastructure.Interfaces.Services;

namespace ClientSide.WebAPI.Controllers
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
        [Route("all_categories")]
        public async Task<IActionResult> GetAllModels()
        {
            var models = await Task.Run(() => Service.DatabaseService
            .Context.Set<ProductCategory>()
            .Include(x => x.ProductSubcategories)
            .Select(x => new ProductCategory()
            {
                ProductCategoryId = x.ProductCategoryId,
                Name = x.Name,
                ProductSubcategories = x.ProductSubcategories
                .Select(z => new ProductSubcategory()
                {
                    ProductSubcategoryId = z.ProductSubcategoryId,
                    Name = z.Name,
                    ProductCategoryId = z.ProductCategoryId
                }
                ).ToList()
            })
            .ToList());
            return new JsonResult(models);
        }
    }
}

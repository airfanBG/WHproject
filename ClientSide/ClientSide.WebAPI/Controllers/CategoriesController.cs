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
            var categories = await Service.GetAllAsync();
            var all=categories.Include(x => x.Products).Select(x =>x.Category()).ToList();
            return new JsonResult(all);
        }
    }
}

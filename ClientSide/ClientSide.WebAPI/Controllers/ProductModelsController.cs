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
    public class ProductModelsController : ControllerBase
    {
        public IBasicWarehouseService<ProductModel> Service { get; }

        public ProductModelsController(IBasicWarehouseService<ProductModel> service)
        {
            Service = service;
        }
        [HttpGet]
        [Route("all-models")]
        public async Task<IActionResult> GetAllModels()
        {
            var models = await Task.Run(() => Service.GetAllAsync().Result.Select(x => new ProductModel() { CatalogDescription = x.CatalogDescription, Instructions = x.Instructions, Name = x.Name, ProductModelId = x.ProductModelId }).ToList());
            return new JsonResult(models);
        }
    }
}

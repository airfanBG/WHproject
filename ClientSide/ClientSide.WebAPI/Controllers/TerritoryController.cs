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
    public class TerritoryController : ControllerBase
    {
        public IBasicWarehouseService<SalesTerritory> Service { get; }
        public TerritoryController(IBasicWarehouseService<SalesTerritory> service)
        {
            Service = service;
        }
        [HttpGet]
        [Route("all_territories")]
        public async Task<IActionResult> GetAll(int customerId)
        {
            var res = await Task.Run(() => Service.GetAllAsync().Result.Select(x => new SalesTerritory() {Group=x.Group,Name=x.Name,CountryRegionCode=x.CountryRegionCode,TerritoryId=x.TerritoryId }).ToList());
            return new JsonResult(res);
        }
    }
}

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
        [Route("all")]
        public async Task<IActionResult> GetAll(int customerId)
        {
          
            return new JsonResult(await Service.GetAllAsync());
        }
    }
}

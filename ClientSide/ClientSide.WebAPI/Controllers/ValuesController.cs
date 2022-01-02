using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utils.Infrastructure.Interfaces.Services;

namespace ClientSide.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController(IBasicWarehouseService<Product> service)
        {
            Service = service;
        }

        public IBasicWarehouseService<Product> Service { get; }

        public IActionResult TEst()
        {
            return Ok(Service.DatabaseService.Context.Set<Product>().ToList());
        }
    }
}

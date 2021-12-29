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
    public class CustomersController : ControllerBase
    {
        public IBasicWarehouseService<Customer> Service { get; }
        public ILogger<CustomersController> Logger { get; }

        public CustomersController(IBasicWarehouseService<Customer> service, ILogger<CustomersController> logger)
        {
            Service = service;
            Logger = logger;
        }
        [HttpGet]
        [Route("{customerId}")]
        public async Task<IActionResult> GetCustomer(int customerId)
        {
            Logger.LogInformation($"User {User?.Identity?.Name} call GetCustomer action");
            var res = await Task.Run(() => Service.DatabaseService.Context.Set<Customer>().Include(x => x.Territory).Select(x => new Customer()
            {
                AccountNumber = x.AccountNumber,
                CustomerId = x.CustomerId,
                PersonId = x.PersonId,
                TerritoryId = x.TerritoryId,
                
                Territory = new SalesTerritory()
                {
                    Name=x.Territory.Name,
                    TerritoryId=x.Territory.TerritoryId,
                    CountryRegionCode=x.Territory.CountryRegionCode,
                   CountryRegionCodeNavigation=x.Territory.CountryRegionCodeNavigation
                }
            }).ToList());
            return new JsonResult(res);
        }
    }
}

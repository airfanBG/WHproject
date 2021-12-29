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
    public class OrdersController : ControllerBase
    {
        public IBasicWarehouseService<SalesOrderHeader> Service { get; }
        public ILogger<OrdersController> Logger { get; }

        public OrdersController(IBasicWarehouseService<SalesOrderHeader> service, ILogger<OrdersController> logger)
        {
            Service = service;
            Logger = logger;
        }


        [HttpGet]
        [Route("customers/{customerId}/all")]
        public async Task<IActionResult> GetAllOrders(int customerId)
        {
            Logger.LogInformation($"User {User?.Identity?.Name} call all GetAllOrders action");

            return new JsonResult(await Service.GetAllAsync(x=>x.CustomerId==customerId));
        }
        [HttpGet]
        [Route("customers/order/{orderId}")]
        public async Task<IActionResult> GetOrder(int customerId, int orderId)
        {
            Logger.LogInformation($"User {User?.Identity?.Name} call GetOrder action");

            return new JsonResult(await Service.GetByIdAsync(orderId));
        }
        [HttpPost]
        [Route("customers/place_order")]
        public async Task<IActionResult> AddOrder(SalesOrderHeader model)
        {
            Logger.LogInformation($"User {User?.Identity?.Name} call AddOrder action");
            model.SalesOrderNumber = Guid.NewGuid().ToString().Substring(0, 10);
            model.PurchaseOrderNumber = Guid.NewGuid().ToString().Substring(0, 10);
            model.AccountNumber = Guid.NewGuid().ToString().Substring(0,5);

            model.Rowguid = Guid.NewGuid();
            model.RevisionNumber = 8;
            model.Status = 1;
            model.OnlineOrderFlag = true;
            model.ModifiedDate = DateTime.UtcNow;
            return new JsonResult(await Service.Add(model));
        }
    }
}

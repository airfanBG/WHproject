using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Utils.Common.Extensions;
using Utils.Infrastructure.Interfaces.Services;

namespace ClientSide.API.Controllers
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
        [Route("{customerId}/all")]
        public async Task<IActionResult> GetAllOrders(int customerId)
        {
            Logger.LogInformation("{Email} {UserId} All Orders {customerId}", User.FindFirst("email"), User.FindFirst("userid"), customerId);
           
            var res=await Task.Run(() => Service.QuerySelector(selector: z => z.SalesOrder(), predicate: x => x.CustomerId == customerId, include: z => z.Include(a => a.SalesOrderDetails), disableTracking: true));
          
            return Ok(res);
        }
     
        [HttpGet]
        [Route("order/{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            Logger.LogInformation("{Email} {UserId} Get order {orderId}", User.FindFirst("email"), User.FindFirst("userid"), orderId);

            var res=await Task.Run(() => Service.QuerySelector(selector: z => z.SalesOrder(), predicate: x => x.SalesOrderId == orderId, include: z => z.Include(a => a.SalesOrderDetails), disableTracking: true));
           
            return Ok(res);
        }
        [HttpPost]
        [Route("order/place-order")]
        public async Task<IActionResult> AddOrder([FromBody]SalesOrderHeader model)
        {
            Logger.LogInformation("{Email} {UserId} Add order", User.FindFirst("email"), User.FindFirst("userid"));
            model.PurchaseOrderNumber ="PO"+ Guid.NewGuid().ToString().Substring(0, 10);
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

using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        [Route("place-order")]
        public async Task<IActionResult> AddOrder([FromBody]SalesOrderHeader model)
        {
            int id= int.Parse(User.FindFirst("userid").Value);
           
            Logger.LogInformation("{Email} {UserId} Add order", User.FindFirst("email"), User.FindFirst("userid"));
            model.PurchaseOrderNumber ="PO"+ Guid.NewGuid().ToString().Substring(0, 10);
            model.AccountNumber = Guid.NewGuid().ToString().Substring(0,5);
            model.CustomerId = id;
            model.Rowguid = Guid.NewGuid();
            model.RevisionNumber = 8;
            model.Status = 1;
            model.OnlineOrderFlag = true;
            model.ModifiedDate = DateTime.UtcNow;
            model.OrderDate= DateTime.UtcNow;
            model.OnlineOrderFlag = User.IsInRole("Customer") ? true : false;
            model.DueDate =model.DueDate==default ? DateTime.UtcNow.AddDays(7) : model.DueDate ;
            model.ShipToAddressId = model.ShipToAddressId;
            model.BillToAddressId = model.BillToAddressId;
            model.ShipMethod = "CARGO TRANSPORT 5";
            
            return new JsonResult(await Service.Add(model));
        }
    

    }
}

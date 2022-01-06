﻿using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

            return new JsonResult(await Task.Run(()=> Service.DatabaseService.Context.Set<SalesOrderHeader>().Where(x=>x.CustomerId==customerId).Include(x=>x.SalesOrderDetails).Select(x=>x.SalesOrder()).AsNoTracking()));
        }
        [HttpGet]
        [Route("order/{orderId}")]
        public async Task<IActionResult> GetOrder(int customerId, int orderId)
        {
            Logger.LogInformation("{Email} {UserId} Get Order {customerId} {orderId}", User.FindFirst("email"), User.FindFirst("userid"), customerId,orderId);

            return new JsonResult(await Task.Run(() => Service.DatabaseService.Context.Set<SalesOrderHeader>().Where(x => x.CustomerId == customerId).Include(x => x.SalesOrderDetails).Where(x=>x.SalesOrderId==orderId).Select(x => x.SalesOrder())));
        }
        [HttpPost]
        [Route("place-order")]
        public async Task<IActionResult> AddOrder([FromBody]SalesOrderHeader model)
        {
            Logger.LogInformation("{Email} {UserId} Add order", User.FindFirst("email"), User.FindFirst("userid"));
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

﻿using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Utils.Common.Extensions;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Infrastructure.Vmodels;

namespace ClientSide.API.Controllers
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
            if (customerId == 0)
            {
                return BadRequest();
            }
            Logger.LogInformation("{UserName} {UserId} Get Customer {customerId}", User.FindFirst("email"), User.FindFirst("userid"),customerId);
            var customer = await Service.GetAllAsync(x => x.CustomerId == customerId);
            var res= customer.Select(x => x.Customer()).FirstOrDefault();
            return new JsonResult(res);
        }
        [HttpGet]
        [Route("customer-orders/{customerId}")]
        public async Task<IActionResult> GetCustomerOrders(int customerId)
        {
            if (customerId == 0)
            {
                return BadRequest();
            }
            Logger.LogInformation("{UserName} {UserId} Get Customer Orders {customerId}", User.FindFirst("email"), User.FindFirst("userid"), customerId);
            var customer =await Task.Run(()=> Service.DatabaseService.Context.Set<Customer>().Where(x => x.CustomerId == customerId).Include(x => x.SalesOrderHeaders).Select(x =>x.CustomerOrders()).ToList()) ;
            return new JsonResult(customer);
        }
        [HttpGet]
        [Route("customer-order/{customerId}/{orderId}")]
        public async Task<IActionResult> GetCustomerOrder(int customerId, int orderId)
        {
            if (customerId==0 || orderId==0)
            {
                return BadRequest();
            }
            Logger.LogInformation("{UserName} {UserId} GetCustomer {customerId} {orderId}", User.FindFirst("email"), User.FindFirst("userid"), customerId,orderId);
            var customer = await Task.Run(() => Service.DatabaseService.Context.Set<Customer>().Where(x => x.CustomerId == customerId).Include(x => x.SalesOrderHeaders).Select(x => x.CustomerOrder(orderId)).FirstOrDefault());
            
            return new JsonResult(customer);
        }
       
    }
}
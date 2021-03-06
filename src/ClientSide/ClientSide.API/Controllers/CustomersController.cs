using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            Logger.LogInformation("{Email} {UserId} Get Customer {customerId}", User.FindFirst("email"), User.FindFirst("userid"),customerId);
            var customer =await Task.Run(()=> Service.GetAll(predicate: x => x.CustomerId == customerId));
            var res= customer.Select(x => x.Customer()).FirstOrDefault();
       
            return Ok(res);
        }
        [HttpGet]
        [Route("customer-orders/{customerId}")]
        public async Task<IActionResult> GetCustomerOrders(int customerId)
        {
            if (customerId == 0)
            {
                return BadRequest();
            }
            Logger.LogInformation("{Email} {UserId} Get Customer Orders {customerId}", User.FindFirst("email"), User.FindFirst("userid"), customerId);

            var customer = await Task.Run(() => Service.QuerySelector(selector: x => x.CustomerOrders(), predicate: x => x.CustomerId == customerId, include: i => i.Include(z => z.SalesOrderHeaders), disableTracking: true).ToList());

            return Ok(customer);
        }
        [HttpGet]
        [Route("customer-order/{customerId}/{orderId}")]
        public async Task<IActionResult> GetCustomerOrder(int customerId, int orderId)
        {
            if (customerId==0 || orderId==0)
            {
                return BadRequest();
            }
            Logger.LogInformation("{Email} {UserId} GetCustomer {customerId} {orderId}", User.FindFirst("email"), User.FindFirst("userid"), customerId,orderId);
            
            var customer = await Task.Run(() => Service.QuerySelector(selector: x => x.CustomerOrder(orderId), predicate: z => z.CustomerId == customerId, include: i => i.Include(x => x.SalesOrderHeaders)).FirstOrDefault());

            return Ok(customer);
        }
       
    }
}

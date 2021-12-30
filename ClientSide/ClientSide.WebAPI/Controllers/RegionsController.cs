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
    public class RegionsController : ControllerBase
    {
        public IBasicWarehouseService<CountryRegion> Service { get; }

        public RegionsController(IBasicWarehouseService<CountryRegion> service)
        {
            Service = service;

        }
        [HttpGet]
        [Route("all-countries")]
        public async Task<IActionResult> GetAll()
        {
            var res = await Task.Run(() => Service.DatabaseService.Context.Set<CountryRegion>().AsNoTracking().Select(x => new CountryRegion()
            {
                
                CountryRegionCode = x.CountryRegionCode,
                Name = x.Name,

            }).ToList());

            return new JsonResult(res);
        }
        [HttpGet]
        [Route("country-regions/{countryCode}")]
        public async Task<IActionResult> GetRegionStates(string countryCode)
        {
            var res = await Task.Run(() => Service.DatabaseService.Context.Set<StateProvince>().AsNoTracking().Where(x=>x.CountryRegionCode==countryCode).Select(z => new StateProvince()
            {
                CountryRegionCode = z.CountryRegionCode,
                Name = z.Name,
                StateProvinceCode = z.StateProvinceCode,
                TerritoryId = z.TerritoryId,
                StateProvinceId = z.StateProvinceId,
            }).ToList());
            return new JsonResult(res);
        }
        [HttpGet]
        [Route("addresses/{provinceId}")]
        public async Task<IActionResult> GetAddressess(int provinceId)
        {
            var res = await Task.Run(() => Service.DatabaseService.Context.Set<Address>().AsNoTracking().Where(x=>x.StateProvinceId==provinceId).Select(a => new Address()
            {
                AddressId = a.AddressId,
                AddressLine1 = a.AddressLine1,
                AddressLine2 = a.AddressLine2,
                City = a.City,
                PostalCode = a.PostalCode,
                StateProvinceId = a.StateProvinceId
            }).ToList());
            return new JsonResult(res);
        }
    }
}

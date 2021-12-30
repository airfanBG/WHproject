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
    public class SpecialOfferController : ControllerBase
    {
        public IBasicWarehouseService<SpecialOffer> Service { get; }

        public SpecialOfferController(IBasicWarehouseService<SpecialOffer> service)
        {
            Service = service;
        }

        [HttpGet]
        [Route("all-offers")]
        public async Task<IActionResult> GetAll()
        {
            var res = await Task.Run(() => Service.DatabaseService.Context.Set<SpecialOffer>().Select(x => new SpecialOffer()
            {
                Category = x.Category,
                Description = x.Description,
                DiscountPct = x.DiscountPct,
                EndDate = x.EndDate,
                MaxQty = x.MaxQty,
                MinQty = x.MinQty,
                SpecialOfferId = x.SpecialOfferId,
                StartDate = x.StartDate,
                Type = x.Type,
                SpecialOfferProducts = x.SpecialOfferProducts

            }).ToList());

            return new JsonResult(res);
        }
        [HttpGet]
        [Route("product-special-offer/{productId}")]
        public async Task<IActionResult> GetOffer(int productId)
        {
            var res = await Task.Run(() => Service.DatabaseService.Context.Set<SpecialOfferProduct>().Where(x=>x.ProductId==productId).Select(x => new SpecialOfferProduct()
            {
                ProductId=x.ProductId,
                SpecialOffer=new SpecialOffer()
                {
                    Category = x.SpecialOffer.Category,
                    Description = x.SpecialOffer.Description,
                    DiscountPct = x.SpecialOffer.DiscountPct,
                    EndDate = x.SpecialOffer.EndDate,
                    MaxQty = x.SpecialOffer.MaxQty,
                    MinQty = x.SpecialOffer.MinQty,
                    SpecialOfferId = x.SpecialOffer.SpecialOfferId,
                    StartDate = x.SpecialOffer.StartDate,
                    Type = x.SpecialOffer.Type,
                   
                }
               

            }).ToList());

            return new JsonResult(res);
        }
    }
}

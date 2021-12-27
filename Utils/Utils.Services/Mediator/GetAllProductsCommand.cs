using Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Infrastructure.Interfaces.Models;
using Utils.Infrastructure.Interfaces.Services;

namespace Utils.Services.Mediator
{
    public class GetAllProductsCommand:IRequest<List<Product>>
    {

    }
    public class GetAllProductsCommandHandler : IRequestHandler<GetAllProductsCommand,List<Product>>
    {
        public GetAllProductsCommandHandler(IBasicWarehouseService<Product> service)
        {
            Service = service;
        }

        public IBasicWarehouseService<Product> Service { get; }

        public async Task<List<Product>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
        {
         
            return await  this.Service.GetAllAsync();
        }
    }
}

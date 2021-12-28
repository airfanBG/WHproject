using Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Infrastructure.Interfaces.Services;

namespace Utils.Services.Mediator
{
    public class GetProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
    }
    public class GetProductCommandHandler : IRequestHandler<GetProductCommand, Product>
    {
        public GetProductCommandHandler(IBasicWarehouseService<Product> service)
        {
            Service = service;
        }

        public IBasicWarehouseService<Product> Service { get; }

     
        public async Task<Product> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
           return await Service.GetByIdAsync(request.Id);
        }
    }
}

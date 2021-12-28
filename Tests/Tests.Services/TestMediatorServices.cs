using Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Services.Mediator;
using Xunit;

namespace Tests.Services
{
    public class TestMediatorServices
    {
        [Fact]
        public async Task Test_GetAll_service()
        {
            var wareHouse = new Mock<IBasicWarehouseService<Product>>();
            wareHouse.Setup(x => x.GetByIdAsync(1));
            GetProductCommand command = new GetProductCommand();
            command.Id = 1;
            GetProductCommandHandler getProductCommandHandler = new GetProductCommandHandler(wareHouse.Object);

            Assert.Equal(1, getProductCommandHandler.Handle(command, default).Id);
        }
    }
}

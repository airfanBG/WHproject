using Data.Models;
using Data.WarehouseContext.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Services.DataServices;
using Xunit;

namespace Tests.Services
{
    public class TestServices
    {
        private DbContextOptions<AdventureWorks2019Context> options = new DbContextOptionsBuilder<AdventureWorks2019Context>().UseSqlServer("Server=.;Database=AdventureWorks2019;Trusted_Connection=True;").Options;
        [Fact]
        public async Task Test_GetAll_service()
        {
            //var wareHouse = new Mock<IBasicWarehouseService>();
            AdventureWorks2019Context context = new AdventureWorks2019Context(options);

            var db = new ApplicationDbContext(context);

            var services = new WarehouseService<Product>(db);

            Assert.NotEmpty(await services.GetAllAsync());
        }
    }
}

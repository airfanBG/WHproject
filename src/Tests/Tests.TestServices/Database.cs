using Data.WarehouseContext.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Utils.Services.DataServices;
using Xunit;

namespace Tests.TestServices
{
    public class Database
    {
        [Fact]
        public void Test_Database_Connection()
        {
            var options = new DbContextOptionsBuilder<AdventureWorks2019Context>().UseSqlServer("Server=.;Database=AdventureWorks2019;Trusted_Connection=True;").Options;

            AdventureWorks2019Context context = new AdventureWorks2019Context(options);


            Assert.NotNull(context.ContextId);
        }
        [Fact]
        public void Test_Disposing_Db_Form_UoW()
        {

            var db = new Mock<DbContext>();
            ApplicationDbContext context = new ApplicationDbContext(db.Object);
            context.Dispose();


            Assert.True(context.IsDisposed);
        }
    }
}

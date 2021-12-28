using Data.WarehouseContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Infrastructure.Vmodels;
using Utils.Services.DataServices;
using Utils.Services.DataServices.Identity;
using Xunit;

namespace Tests.Services
{
    public class TestIdentity
    {
        private DbContextOptions<AdventureWorks2019Context> options = new DbContextOptionsBuilder<AdventureWorks2019Context>().UseSqlServer("Server=.;Database=AdventureWorks2019;Trusted_Connection=True;").Options;

        [Fact]
        public async Task Test_Register()
        {
            //Arrange
            var inMemorySettings = new Dictionary<string, string> {
                    {"Iterations", "1500"},
                   
              };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            AdventureWorks2019Context context = new AdventureWorks2019Context(options);

            var db = new ApplicationDbContext(context);

            IdentityService service = new IdentityService(configuration, db);
            RegisterModel model = new RegisterModel()
            {
                Email = "ken0@adventure-works.com",
                Password = "123",
                ConfirmPassword = "123",
            };
            //Act
            var res=await service.RegisterAsync(model);

            //Assert
            Assert.Equal(1, res);
        }
        [Fact]
        public async Task Test_Register_Invalid_Email()
        {
            //Arrange
            var inMemorySettings = new Dictionary<string, string> {
                    {"Iterations", "1500"},

              };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            AdventureWorks2019Context context = new AdventureWorks2019Context(options);

            var db = new ApplicationDbContext(context);

            IdentityService service = new IdentityService(configuration, db);
            RegisterModel model = new RegisterModel()
            {
                Email = "ke@adventure-works.com",
                Password = "123",
                ConfirmPassword = "123",
            };
            //Act
            var res = await service.RegisterAsync(model);

            //Assert
            Assert.Equal(0, res);
        }
        [Fact]
        public async Task Test_Register_Invalid_Password()
        {
            //Arrange
            var inMemorySettings = new Dictionary<string, string> {
                    {"Iterations", "1500"},

              };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            AdventureWorks2019Context context = new AdventureWorks2019Context(options);

            var db = new ApplicationDbContext(context);

            IdentityService service = new IdentityService(configuration, db);
            RegisterModel model = new RegisterModel()
            {
                Email = "ke0@adventure-works.com",
                Password = "12",
                ConfirmPassword = "123",
            };
            //Act
            var res = await service.RegisterAsync(model);

            //Assert
            Assert.Equal(0, res);
        }
        [Fact]
        public async Task Test_Login()
        {
            //Arrange
            var inMemorySettings = new Dictionary<string, string> {
                    {"JWT:TokenSecret", "Secret"},
                    {"JWT:ValidIssuer", "localhost:5000"},
                    {"JWT:ValidAudience", "localhost:5000"},
                    {"JWT:Expiration", "3"},

              };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            AdventureWorks2019Context context = new AdventureWorks2019Context(options);

            var db = new ApplicationDbContext(context);

            IdentityService service = new IdentityService(configuration, db);
            LoginModel model = new LoginModel()
            {
                Email = "ken0@adventure-works.com",
                Password = "123"
            };
            //Act
            var res = await service.LoginAsync(model);

            //Assert
            Assert.NotNull(res);
        }
    }
}

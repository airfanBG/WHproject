using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSide.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseSerilog((ctx, lc) =>
               lc.WriteTo.MSSqlServer(
                               connectionString: ctx.Configuration.GetConnectionString("DefaultConnection"),
                               tableName: ctx.Configuration.GetSection("Serilog:TableName").Value,
                               appConfiguration: ctx.Configuration,
                               autoCreateSqlTable: true,
                               columnOptionsSection: ctx.Configuration.GetSection("Serilog:ColumnOptions"),
                               schemaName: ctx.Configuration.GetSection("Serilog:SchemaName").Value)
                           )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

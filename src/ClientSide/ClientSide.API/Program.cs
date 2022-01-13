using ClientSide.API.Qscheduler;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Utils.Common.MagicStrings;

namespace ClientSide.API
{
    public class Program
    {
       

        public static void Main(string[] args)
        {
         
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
           .ConfigureServices((hostContext, services) =>
           {
               services.AddQuartz(q =>
               {
                   q.UseMicrosoftDependencyInjectionJobFactory();

                   q.AddJobAndTrigger<Qjob>(hostContext.Configuration);
                  
               });
               services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
              
           })
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

using Data.WarehouseContext.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Utils.Common.MagicStrings;
using Utils.Common.SQLcommands;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Services.DataServices;
using Utils.Services.DataServices.Identity;

namespace ClientSide.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddScoped(typeof(IBasicWarehouseService<>), typeof(WarehouseService<>));
            services.AddScoped<IuserIdentityService, IdentityService>();
            services.AddScoped<IDatabaseService, ApplicationDbContext>();
            services.AddScoped<DbContext, AdventureWorks2019Context>();
            services.AddDbContext<AdventureWorks2019Context>(o => { o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")); });

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });
            //JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })

                       // Adding Jwt Bearer  
                       .AddJwtBearer(options =>
                       {
                           options.SaveToken = true;
                           options.RequireHttpsMetadata = false;

                           options.TokenValidationParameters = new TokenValidationParameters()
                           {

                               ValidateIssuer = true,
                               ValidateAudience = true,
                               ValidAudience = Configuration[ConfigurationKeys.JWT_ValidAudience],
                               ValidIssuer = Configuration[ConfigurationKeys.JWT_ValidIssuer],
                               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[ConfigurationKeys.JWT_TokenSecret]))
                           };

                       });
            services.AddAuthorization();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClientSide.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClientSide.API v1"));
            }

            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var service = scope.ServiceProvider;
                    try
                    {
                        var context = service.GetRequiredService<IDatabaseService>();
                        if (!context.Context.Database.GetService<IRelationalDatabaseCreator>().Exists())
                        {
                            var connectionString = Configuration["InitialConnection"];
                            SqlFunctions.RestoreDb(connectionString, Path.Combine(env.ContentRootPath, "DatabaseBackup\\AdventureWorksLT2019.sql"));
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }

            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Data.WarehouseContext.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Utils.Common.MagicStrings;
using Utils.Common.SQLcommands;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Services.DataServices;
using Utils.Services.DataServices.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
//Serilog

builder.Host.UseSerilog((ctx, lc) =>
   lc.WriteTo.MSSqlServer(
                   connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
                   tableName: builder.Configuration.GetSection("Serilog:TableName").Value,
                   appConfiguration: builder.Configuration,
                   autoCreateSqlTable: true,
                   columnOptionsSection: builder.Configuration.GetSection("Serilog:ColumnOptions"),
                   schemaName: builder.Configuration.GetSection("Serilog:SchemaName").Value)
               );


//services

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IBasicWarehouseService<>), typeof(WarehouseService<>));
builder.Services.AddScoped<IuserIdentityService, IdentityService>();
builder.Services.AddScoped<IDatabaseService, ApplicationDbContext>();
builder.Services.AddScoped<DbContext, AdventureWorks2019Context>();
builder.Services.AddDbContext<AdventureWorks2019Context>(o => { o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });
//JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
});
//JWT
builder.Services.AddAuthentication(options =>
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
                   ValidAudience = builder.Configuration[ConfigurationKeys.JWT_ValidAudience],
                   ValidIssuer = builder.Configuration[ConfigurationKeys.JWT_ValidIssuer],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration[ConfigurationKeys.JWT_TokenSecret]))
               };

           });
builder.Services.AddAuthorization();
var app = builder.Build();

//TODO auto restore database
if (builder.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    try
    {
        var context = service.GetRequiredService<IDatabaseService>();
        if (!context.Context.Database.GetService<IRelationalDatabaseCreator>().Exists())
        {
            var connectionString = builder.Configuration["InitialConnection"];
            SqlFunctions.RestoreDb(connectionString, Path.Combine(builder.Environment.ContentRootPath, "DatabaseBackup\\AdventureWorksLT2019.sql"));
        }
    }
    catch (Exception e)
    {
        throw e;
    }
}

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


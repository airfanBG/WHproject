using Data.WarehouseContext.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
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


////configuration
//IConfiguration configuration = new ConfigurationBuilder()
//       .SetBasePath(Directory.GetCurrentDirectory())
//       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//       .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
//       .Build();

//builder.Services.AddSingleton<IConfiguration>(configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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

using (var scope=app.Services.CreateScope())
{
    var service= scope.ServiceProvider;
    try
    {
        var context = service.GetRequiredService<IDatabaseService>();
        if (context.Context.Database.EnsureCreated())
        {

            
        }
    }
    catch (Exception)
    {

        throw;
    }
}
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    try
//    {
//        var context = services.GetRequiredService<IDatabaseService>();
//        var res=context.ExecuteNonEFquery(SqlFunctions.checkCreatedFunctions);

//       // var addedFunctions = context.Database.ExecuteSqlRaw(SqlFunctions.checkCreatedCustomerOrderFunction);
//        if (res==0)
//        {
//            await context.Context.Database.ExecuteSqlRawAsync(SqlFunctions.UserFunctions);
//        }
       

//    }
//    catch (Exception ex)
//    {

//        throw;
//    }
//}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Use((i, o) =>
{
    var test = i;
    return o.Invoke();
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

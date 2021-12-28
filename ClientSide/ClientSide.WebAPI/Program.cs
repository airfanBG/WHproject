using Data.WarehouseContext.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using Utils.Common.MagicStrings;
using Utils.Infrastructure.Interfaces.Services;
using Utils.Services.DataServices;
using Utils.Services.DataServices.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

IConfiguration configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appSettings.json", false)
       .Build();
builder.Services.AddSingleton<IConfiguration>(configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IBasicWarehouseService<>), typeof(WarehouseService<>));
builder.Services.AddScoped<IuserIdentityService, IdentityService>();
builder.Services.AddScoped<IDatabaseService, ApplicationDbContext>();
builder.Services.AddScoped<DbContext, AdventureWorks2019Context>();
builder.Services.AddDbContext<AdventureWorks2019Context>(o => { o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

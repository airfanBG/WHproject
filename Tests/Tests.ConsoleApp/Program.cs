// See https://aka.ms/new-console-template for more information
using Data.Models;
using Data.WarehouseContext.Models;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<AdventureWorks2019Context>().UseSqlServer("Server=.;Database=AdventureWorks2019;Trusted_Connection=True;").Options;

AdventureWorks2019Context context = new AdventureWorks2019Context(options);

var res=context.Products.Include(x=>x.BillOfMaterialComponents).ToList();

foreach (var product in res)
{

}

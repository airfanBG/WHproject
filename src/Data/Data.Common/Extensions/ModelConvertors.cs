using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Infrastructure.Vmodels;

namespace Utils.Common.Extensions
{
    public static class ModelConvertors
    {
        public static CustomerVM Customer(this Customer model)
        {
            return new CustomerVM()
            {

                CustomerId = model.CustomerId,
                EmailAddress = model.EmailAddress,
                CompanyName = model.CompanyName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                MiddleName = model.MiddleName,
                Title = model.Title
            };
        }
        public static CustomerVM CustomerOrders(this Customer model)
        {
            return new CustomerVM()
            {

                CustomerId = model.CustomerId,
                EmailAddress = model.EmailAddress,
                CompanyName = model.CompanyName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                MiddleName = model.MiddleName,
                Title = model.Title,
                SalesOrderHeaders = model.SalesOrderHeaders.Select(x => new SalesOrderHeaderVM()
                {
                    AccountNumber = x.AccountNumber,
                    OrderDate = x.OrderDate,
                    ShipDate = x.ShipDate,
                    TotalDue = x.TotalDue,
                    DueDate = x.DueDate,
                    Comment = x.Comment,
                    SalesOrderNumber = x.SalesOrderNumber,
                    ShipMethod = x.ShipMethod,
                    Status = x.Status,
                    SubTotal = x.SubTotal,

                }).ToList()
            };
        }
        public static CustomerVM CustomerOrder(this Customer model, int orderId)
        {
            return new CustomerVM()
            {

                CustomerId = model.CustomerId,
                EmailAddress = model.EmailAddress,
                CompanyName = model.CompanyName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                MiddleName = model.MiddleName,
                Title = model.Title,
                SalesOrder = model.SalesOrderHeaders.Where(z => z.SalesOrderId == orderId).Select(x => new SalesOrderHeaderVM()
                {
                    SalesOrderId=x.SalesOrderId,
                    RevisionNumber=x.RevisionNumber,
                    AccountNumber = x.AccountNumber,
                    OrderDate = x.OrderDate,
                    ShipDate = x.ShipDate,
                    TotalDue = x.TotalDue,
                    DueDate = x.DueDate,
                    Comment = x.Comment,
                    SalesOrderNumber = x.SalesOrderNumber,
                    ShipMethod = x.ShipMethod,
                    Status = x.Status,
                    SubTotal = x.SubTotal,

                }).FirstOrDefault()!
            };
        }

        public static ProductVM Product(this Product model)
        {
            return new ProductVM()
            {
                Name = model.Name,
                Color = model.Color,
                ListPrice = model.ListPrice,
                ProductId = model.ProductId,
                ProductNumber = model.ProductNumber,
                Size = model.Size,
                SellStartDate = model.SellStartDate,
                SellEndDate = model.SellEndDate,
                DiscontinuedDate = model.DiscontinuedDate,
                Weight = model.Weight,
                ProductModel = new ProductModelVM()
                {
                    CatalogDescription = model.ProductModel.CatalogDescription,
                    Name = model.ProductModel.Name,
                    ProductModelId = model.ProductModel.ProductModelId,
                    ProductModelProductDescriptions = model.ProductModel.ProductModelProductDescriptions.Select(z => new ProductModelDescriptionVM()
                    {
                        ProductDescriptionId=z.ProductDescriptionId,
                        Description = z.ProductDescription.Description
                    }).ToList()
                },
                StandardCost = model.StandardCost,
                ThumbNailPhoto = model.PhotoBytes,
                ProductCategory = new ProductCategoryVM()
                {
                    Name = model.ProductCategory.Name,
                    ProductCategoryId = model.ProductCategory.ProductCategoryId,

                }
            };
        }

        public static ProductCategoryVM Category(this ProductCategory model)
        {
            return new ProductCategoryVM()
            {
                ProductCategoryId = model.ProductCategoryId,
                Name = model.Name,
               
            };
        }
        public static ProductCategoryVM CategoryWithProducts(this ProductCategory model)
        {
            return new ProductCategoryVM()
            {
                ProductCategoryId = model.ProductCategoryId,
                Name = model.Name,
                Products = model.Products
                .Select(z => new ProductVM()
                {
                    Name = z.Name,
                    Color = z.Color,
                    ListPrice = z.ListPrice,
                    ProductId = z.ProductId,
                    ProductNumber = z.ProductNumber,
                    Size = z.Size,
                    SellStartDate = z.SellStartDate,
                    SellEndDate = z.SellEndDate,
                    DiscontinuedDate = z.DiscontinuedDate,
                    Weight = z.Weight,
                    StandardCost = z.StandardCost,
                    ThumbNailPhoto = z.PhotoBytes,
                }).ToList()

            };
        }

        public static SalesOrderHeaderVM SalesOrder(this SalesOrderHeader model)
        {
            return new SalesOrderHeaderVM()
            {
                SalesOrderId = model.SalesOrderId,
                AccountNumber = model.AccountNumber,
                TaxAmt = model.TaxAmt,
                Comment = model.Comment,
                DueDate = model.DueDate,
                Freight = model.Freight,
                OnlineOrderFlag = model.OnlineOrderFlag,
                OrderDate = model.OrderDate,
                PurchaseOrderNumber = model.PurchaseOrderNumber,
                RevisionNumber = model.RevisionNumber,
                SalesOrderNumber = model.SalesOrderNumber,
                ShipDate = model.ShipDate,
                ShipMethod = model.ShipMethod,
                Status = model.Status,
                SubTotal = model.SubTotal,
                TotalDue = model.TotalDue,
                SalesOrderDetails=model.SalesOrderDetails.Select(x=> new SalesOrderDetailVM()
                {
                    SalesOrderDetailId = x.SalesOrderId,
                    LineTotal=x.LineTotal,
                    OrderQty=x.OrderQty,
                    ProductId=x.ProductId,
                    SalesOrderId=x.SalesOrderId,
                    UnitPrice   =x.UnitPrice,
                    UnitPriceDiscount   =x.UnitPriceDiscount
                }).ToList()
            };
        }
    }
}

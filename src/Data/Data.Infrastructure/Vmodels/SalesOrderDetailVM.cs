using Data.Infrastructure.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Infrastructure.Vmodels
{
    public class SalesOrderDetailVM : IVmodel
    {
        /// <summary>
        /// Primary key. Foreign key to SalesOrderHeader.SalesOrderID.
        /// </summary>
        public int SalesOrderId { get; set; }
        /// <summary>
        /// Primary key. One incremental unique number per product sold.
        /// </summary>
        public int SalesOrderDetailId { get; set; }
        /// <summary>
        /// Quantity ordered per product.
        /// </summary>
        public short OrderQty { get; set; }
        /// <summary>
        /// Product sold to customer. Foreign key to Product.ProductID.
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Selling price of a single product.
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// Discount amount.
        /// </summary>
        public decimal UnitPriceDiscount { get; set; }
        /// <summary>
        /// Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.
        /// </summary>
        public decimal LineTotal { get; set; }
    }
}

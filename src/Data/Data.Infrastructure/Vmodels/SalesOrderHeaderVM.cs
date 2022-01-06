using Data.Infrastructure.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Infrastructure.Vmodels
{
    public class SalesOrderHeaderVM : IVmodel
    {
        public int SalesOrderId { get; set; }
        /// <summary>
        /// Incremental number to track changes to the sales order over time.
        /// </summary>
        public byte RevisionNumber { get; set; }
        /// <summary>
        /// Dates the sales order was created.
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Date the order is due to the customer.
        /// </summary>
        public DateTime DueDate { get; set; }
        /// <summary>
        /// Date the order was shipped to the customer.
        /// </summary>
        public DateTime? ShipDate { get; set; }
        /// <summary>
        /// Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 0 = Order placed by sales person. 1 = Order placed online by customer.
        /// </summary>
        public bool? OnlineOrderFlag { get; set; }
        /// <summary>
        /// Unique sales order identification number.
        /// </summary>
        public string SalesOrderNumber { get; set; } = null!;
        /// <summary>
        /// Customer purchase order number reference. 
        /// </summary>
        public string? PurchaseOrderNumber { get; set; }
        /// <summary>
        /// Financial accounting number reference.
        /// </summary>
        public string? AccountNumber { get; set; }
        
        /// <summary>
        /// Shipping method. Foreign key to ShipMethod.ShipMethodID.
        /// </summary>
        public string ShipMethod { get; set; } = null!;
        /// <summary>
        /// Approval code provided by the credit card company.
        /// </summary>
        public string? CreditCardApprovalCode { get; set; }
        /// <summary>
        /// Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.
        /// </summary>
        public decimal SubTotal { get; set; }
        /// <summary>
        /// Tax amount.
        /// </summary>
        public decimal TaxAmt { get; set; }
        /// <summary>
        /// Shipping cost.
        /// </summary>
        public decimal Freight { get; set; }
        /// <summary>
        /// Total due from customer. Computed as Subtotal + TaxAmt + Freight.
        /// </summary>
        public decimal TotalDue { get; set; }
        /// <summary>
        /// Sales representative comments.
        /// </summary>
        public string? Comment { get; set; }
        public ICollection<SalesOrderDetailVM> SalesOrderDetails { get; set; }

    }
}

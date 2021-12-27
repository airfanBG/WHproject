using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Cross-reference table mapping sales orders to sales reason codes.
    /// </summary>
    public class SalesOrderHeaderSalesReason : IBaseModel
    {
        /// <summary>
        /// Primary key. Foreign key to SalesOrderHeader.SalesOrderID.
        /// </summary>
        public int SalesOrderId { get; set; }
        /// <summary>
        /// Primary key. Foreign key to SalesReason.SalesReasonID.
        /// </summary>
        public int SalesReasonId { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public SalesOrderHeader SalesOrder { get; set; } = null!;
        public SalesReason SalesReason { get; set; } = null!;
    }
}

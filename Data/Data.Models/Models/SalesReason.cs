using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Lookup table of customer purchase reasons.
    /// </summary>
    public class SalesReason : IBaseModel
    {
        public SalesReason()
        {
            SalesOrderHeaderSalesReasons = new HashSet<SalesOrderHeaderSalesReason>();
        }

        /// <summary>
        /// Primary key for SalesReason records.
        /// </summary>
        public int SalesReasonId { get; set; }
        /// <summary>
        /// Sales reason description.
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Category the sales reason belongs to.
        /// </summary>
        public string ReasonType { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public ICollection<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }
    }
}

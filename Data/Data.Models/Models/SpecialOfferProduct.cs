using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Cross-reference table mapping products to special offer discounts.
    /// </summary>
    public class SpecialOfferProduct : IBaseModel
    {
        public SpecialOfferProduct()
        {
            SalesOrderDetails = new HashSet<SalesOrderDetail>();
        }

        /// <summary>
        /// Primary key for SpecialOfferProduct records.
        /// </summary>
        public int SpecialOfferId { get; set; }
        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        public Guid Rowguid { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public Product Product { get; set; } = null!;
        public SpecialOffer SpecialOffer { get; set; } = null!;
        public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}

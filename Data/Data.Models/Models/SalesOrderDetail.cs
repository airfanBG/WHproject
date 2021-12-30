﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Individual products associated with a specific sales order. See SalesOrderHeader.
    /// </summary>
    public class SalesOrderDetail : BaseModel
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
        /// Shipment tracking number supplied by the shipper.
        /// </summary>
        public string? CarrierTrackingNumber { get; set; }
        /// <summary>
        /// Quantity ordered per product.
        /// </summary>
        [Required]
        public short OrderQty { get; set; }
        /// <summary>
        /// Product sold to customer. Foreign key to Product.ProductID.
        /// </summary>
        [Required]
        public int ProductId { get; set; }
        /// <summary>
        /// Promotional code. Foreign key to SpecialOffer.SpecialOfferID.
        /// </summary>
        public int SpecialOfferId { get; set; }
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
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
      //  public Guid Rowguid { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
      //  public DateTime ModifiedDate { get; set; }

        public SalesOrderHeader SalesOrder { get; set; } = null!;
        public SpecialOfferProduct SpecialOfferProduct { get; set; } = null!;
    }
}

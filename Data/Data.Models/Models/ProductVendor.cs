﻿using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Cross-reference table mapping vendors with the products they supply.
    /// </summary>
    public class ProductVendor : IBaseModel
    {
        /// <summary>
        /// Primary key. Foreign key to Product.ProductID.
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Primary key. Foreign key to Vendor.BusinessEntityID.
        /// </summary>
        public int BusinessEntityId { get; set; }
        /// <summary>
        /// The average span of time (in days) between placing an order with the vendor and receiving the purchased product.
        /// </summary>
        public int AverageLeadTime { get; set; }
        /// <summary>
        /// The vendor&apos;s usual selling price.
        /// </summary>
        public decimal StandardPrice { get; set; }
        /// <summary>
        /// The selling price when last purchased.
        /// </summary>
        public decimal? LastReceiptCost { get; set; }
        /// <summary>
        /// Date the product was last received by the vendor.
        /// </summary>
        public DateTime? LastReceiptDate { get; set; }
        /// <summary>
        /// The maximum quantity that should be ordered.
        /// </summary>
        public int MinOrderQty { get; set; }
        /// <summary>
        /// The minimum quantity that should be ordered.
        /// </summary>
        public int MaxOrderQty { get; set; }
        /// <summary>
        /// The quantity currently on order.
        /// </summary>
        public int? OnOrderQty { get; set; }
        /// <summary>
        /// The product&apos;s unit of measure.
        /// </summary>
        public string UnitMeasureCode { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public Vendor BusinessEntity { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public UnitMeasure UnitMeasureCodeNavigation { get; set; } = null!;
    }
}

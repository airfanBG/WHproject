using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Unit of measure lookup table.
    /// </summary>
    public class UnitMeasure : IBaseModel
    {
        public UnitMeasure()
        {
            BillOfMaterials = new HashSet<BillOfMaterial>();
            ProductSizeUnitMeasureCodeNavigations = new HashSet<Product>();
            ProductVendors = new HashSet<ProductVendor>();
            ProductWeightUnitMeasureCodeNavigations = new HashSet<Product>();
        }

        /// <summary>
        /// Primary key.
        /// </summary>
        public string UnitMeasureCode { get; set; } = null!;
        /// <summary>
        /// Unit of measure description.
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public ICollection<BillOfMaterial> BillOfMaterials { get; set; }
        public ICollection<Product> ProductSizeUnitMeasureCodeNavigations { get; set; }
        public ICollection<ProductVendor> ProductVendors { get; set; }
        public ICollection<Product> ProductWeightUnitMeasureCodeNavigations { get; set; }
    }
}

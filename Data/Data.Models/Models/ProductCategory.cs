using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// High-level product categorization.
    /// </summary>
    public partial class ProductCategory : BaseModel
    {
        public ProductCategory()
        {
            InverseParentProductCategory = new HashSet<ProductCategory>();
            Products = new HashSet<Product>();
        }

        /// <summary>
        /// Primary key for ProductCategory records.
        /// </summary>
        public int ProductCategoryId { get; set; }
        /// <summary>
        /// Product category identification number of immediate ancestor category. Foreign key to ProductCategory.ProductCategoryID.
        /// </summary>
        public int? ParentProductCategoryId { get; set; }
        /// <summary>
        /// Category description.
        /// </summary>
        public string Name { get; set; } = null!;
      

        public virtual ProductCategory? ParentProductCategory { get; set; }
        public virtual ICollection<ProductCategory> InverseParentProductCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

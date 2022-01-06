using Data.Infrastructure.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Infrastructure.Vmodels
{
    public class ProductCategoryVM : IVmodel
    {
        public int ProductCategoryId { get; set; }
        /// <summary>
        /// Product category identification number of immediate ancestor category. Foreign key to ProductCategory.ProductCategoryID.
        /// </summary>
        public int? ParentProductCategoryId { get; set; }
        /// <summary>
        /// Category description.
        /// </summary>
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductVM> Products { get; set; }
    }
}

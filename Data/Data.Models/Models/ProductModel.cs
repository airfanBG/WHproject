using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    public partial class ProductModel : BaseModel
    {
        public ProductModel()
        {
            ProductModelProductDescriptions = new HashSet<ProductModelProductDescription>();
            Products = new HashSet<Product>();
        }

        public int ProductModelId { get; set; }
        public string Name { get; set; } = null!;
        public string? CatalogDescription { get; set; }
       
        public virtual ICollection<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

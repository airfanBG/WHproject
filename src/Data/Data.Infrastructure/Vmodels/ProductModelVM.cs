using Data.Infrastructure.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Infrastructure.Vmodels
{
    public class ProductModelVM : IVmodel
    {
        public int ProductModelId { get; set; }
        public string Name { get; set; } = null!;
        public string? CatalogDescription { get; set; }

        public virtual ICollection<ProductModelDescriptionVM> ProductModelProductDescriptions { get; set; }
        public virtual ICollection<ProductVM> Products { get; set; }
    }
}

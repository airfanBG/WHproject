using Data.Infrastructure.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Infrastructure.Vmodels
{
    public class ProductModelDescriptionVM : IVmodel
    {
        public int ProductDescriptionId { get; set; }
        /// <summary>
        /// Description of the product.
        /// </summary>
        public string Description { get; set; } = null!;
    }
}

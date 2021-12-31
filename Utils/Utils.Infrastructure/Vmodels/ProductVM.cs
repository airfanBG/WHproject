using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Infrastructure.Vmodels
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        /// <summary>
        /// Name of the product.
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Unique product identification number.
        /// </summary>
        public string ProductNumber { get; set; } = null!;
        /// <summary>
        /// Product color.
        /// </summary>
        public string? Color { get; set; }
        /// <summary>
        /// Standard cost of the product.
        /// </summary>
        public decimal StandardCost { get; set; }
        /// <summary>
        /// Selling price.
        /// </summary>
        public decimal ListPrice { get; set; }
        /// <summary>
        /// Product size.
        /// </summary>
        public string? Size { get; set; }
        /// <summary>
        /// Product weight.
        /// </summary>
        public decimal? Weight { get; set; }
        /// <summary>
        /// Date the product was available for sale.
        /// </summary>
        public DateTime SellStartDate { get; set; }
        /// <summary>
        /// Date the product was no longer available for sale.
        /// </summary>
        public DateTime? SellEndDate { get; set; }
        /// <summary>
        /// Date the product was discontinued.
        /// </summary>
        public DateTime? DiscontinuedDate { get; set; }
        /// <summary>
        /// Small image of the product.
        /// </summary>
        public byte[]? ThumbNailPhoto { get; set; }
        /// <summary>
        /// Small image file name.
        /// </summary>
        public string? ThumbnailPhotoFileName { get; set; }


        public virtual ProductCategoryVM? ProductCategory { get; set; }
        public virtual ProductModelVM? ProductModel { get; set; }
    }
}

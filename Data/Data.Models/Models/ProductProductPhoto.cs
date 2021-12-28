using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Cross-reference table mapping products and product photos.
    /// </summary>
    public class ProductProductPhoto : BaseModel
    {
        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.
        /// </summary>
        public int ProductPhotoId { get; set; }
        /// <summary>
        /// 0 = Photo is not the principal image. 1 = Photo is the principal image.
        /// </summary>
        public bool Primary { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public Product Product { get; set; } = null!;
        public ProductPhoto ProductPhoto { get; set; } = null!;
    }
}

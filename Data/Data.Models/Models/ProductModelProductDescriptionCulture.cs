using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Cross-reference table mapping product descriptions and the language the description is written in.
    /// </summary>
    public class ProductModelProductDescriptionCulture : BaseModel
    {
        /// <summary>
        /// Primary key. Foreign key to ProductModel.ProductModelID.
        /// </summary>
        public int ProductModelId { get; set; }
        /// <summary>
        /// Primary key. Foreign key to ProductDescription.ProductDescriptionID.
        /// </summary>
        public int ProductDescriptionId { get; set; }
        /// <summary>
        /// Culture identification number. Foreign key to Culture.CultureID.
        /// </summary>
        public string CultureId { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public Culture Culture { get; set; } = null!;
        public ProductDescription ProductDescription { get; set; } = null!;
        public ProductModel ProductModel { get; set; } = null!;
    }
}

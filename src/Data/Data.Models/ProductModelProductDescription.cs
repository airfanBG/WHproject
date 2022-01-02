using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Cross-reference table mapping product descriptions and the language the description is written in.
    /// </summary>
    public partial class ProductModelProductDescription : BaseModel
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
        /// The culture for which the description is written
        /// </summary>
        public string Culture { get; set; } = null!;
     

        public virtual ProductDescription ProductDescription { get; set; } = null!;
        public virtual ProductModel ProductModel { get; set; } = null!;
    }
}

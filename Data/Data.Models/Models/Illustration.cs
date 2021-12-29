using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Bicycle assembly diagrams.
    /// </summary>
    public class Illustration : BaseModel
    {
        public Illustration()
        {
            ProductModelIllustrations = new HashSet<ProductModelIllustration>();
        }

        /// <summary>
        /// Primary key for Illustration records.
        /// </summary>
        public int IllustrationId { get; set; }
        /// <summary>
        /// Illustrations used in manufacturing instructions. Stored as XML.
        /// </summary>
        public string? Diagram { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
      //  public DateTime ModifiedDate { get; set; }

        public ICollection<ProductModelIllustration> ProductModelIllustrations { get; set; }
    }
}

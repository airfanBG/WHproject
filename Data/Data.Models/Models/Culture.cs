using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Lookup table containing the languages in which some AdventureWorks data is stored.
    /// </summary>
    public class Culture : IBaseModel
    {
        public Culture()
        {
            ProductModelProductDescriptionCultures = new HashSet<ProductModelProductDescriptionCulture>();
        }

        /// <summary>
        /// Primary key for Culture records.
        /// </summary>
        public string CultureId { get; set; } = null!;
        /// <summary>
        /// Culture description.
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }
    }
}

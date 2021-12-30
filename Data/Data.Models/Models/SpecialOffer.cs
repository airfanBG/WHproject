using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Sale discounts lookup table.
    /// </summary>
    public class SpecialOffer : BaseModel
    {
        public SpecialOffer()
        {
            SpecialOfferProducts = new HashSet<SpecialOfferProduct>();
        }

        /// <summary>
        /// Primary key for SpecialOffer records.
        /// </summary>
        public int SpecialOfferId { get; set; }
        /// <summary>
        /// Discount description.
        /// </summary>
        [Required]
        public string Description { get; set; } = null!;
        /// <summary>
        /// Discount precentage.
        /// </summary>
        [Required]
        public decimal DiscountPct { get; set; }
        /// <summary>
        /// Discount type category.
        /// </summary>
        [Required]
        public string Type { get; set; } = null!;
        /// <summary>
        /// Group the discount applies to such as Reseller or Customer.
        /// </summary>
        [Required]
        public string Category { get; set; } = null!;
        /// <summary>
        /// Discount start date.
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Discount end date.
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Minimum discount percent allowed.
        /// </summary>
        [Required]
        public int MinQty { get; set; }
        /// <summary>
        /// Maximum discount percent allowed.
        /// </summary>
        [Required]
        public int? MaxQty { get; set; }
      
        public ICollection<SpecialOfferProduct> SpecialOfferProducts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Manufacturing failure reasons lookup table.
    /// </summary>
    public class ScrapReason : BaseModel
    {
        public ScrapReason()
        {
            WorkOrders = new HashSet<WorkOrder>();
        }

        /// <summary>
        /// Primary key for ScrapReason records.
        /// </summary>
        public short ScrapReasonId { get; set; }
        /// <summary>
        /// Failure description.
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
      //  public DateTime ModifiedDate { get; set; }

        public ICollection<WorkOrder> WorkOrders { get; set; }
    }
}

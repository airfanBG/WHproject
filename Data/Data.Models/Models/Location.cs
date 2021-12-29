using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Product inventory and manufacturing locations.
    /// </summary>
    public class Location : BaseModel
    {
        public Location()
        {
            ProductInventories = new HashSet<ProductInventory>();
            WorkOrderRoutings = new HashSet<WorkOrderRouting>();
        }

        /// <summary>
        /// Primary key for Location records.
        /// </summary>
        public short LocationId { get; set; }
        /// <summary>
        /// Location description.
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Standard hourly cost of the manufacturing location.
        /// </summary>
        public decimal CostRate { get; set; }
        /// <summary>
        /// Work capacity (in hours) of the manufacturing location.
        /// </summary>
        public decimal Availability { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
      //  public DateTime ModifiedDate { get; set; }

        public ICollection<ProductInventory> ProductInventories { get; set; }
        public ICollection<WorkOrderRouting> WorkOrderRoutings { get; set; }
    }
}

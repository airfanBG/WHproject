using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Cross-reference table mapping customers to their address(es).
    /// </summary>
    public partial class CustomerAddress : BaseModel
    {
        /// <summary>
        /// Primary key. Foreign key to Customer.CustomerID.
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Primary key. Foreign key to Address.AddressID.
        /// </summary>
        public int AddressId { get; set; }
        /// <summary>
        /// The kind of Address. One of: Archive, Billing, Home, Main Office, Primary, Shipping
        /// </summary>
        public string AddressType { get; set; } = null!;
       

        public virtual Address Address { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
    }
}

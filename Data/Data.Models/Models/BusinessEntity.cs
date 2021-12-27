using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Source of the ID that connects vendors, customers, and employees with address and contact information.
    /// </summary>
    public class BusinessEntity:IBaseModel
    {
        public BusinessEntity()
        {
            BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
            BusinessEntityContacts = new HashSet<BusinessEntityContact>();
        }

        /// <summary>
        /// Primary key for all customers, vendors, and employees.
        /// </summary>
        public int BusinessEntityId { get; set; }
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        public Guid Rowguid { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public Person Person { get; set; } = null!;
        public Store Store { get; set; } = null!;
        public Vendor Vendor { get; set; } = null!;
        public ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        public ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; }
    }
}

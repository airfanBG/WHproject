using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Street address information for customers, employees, and vendors.
    /// </summary>
    public class Address:IBaseModel
    {
        public Address()
        {
            BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
            SalesOrderHeaderBillToAddresses = new HashSet<SalesOrderHeader>();
            SalesOrderHeaderShipToAddresses = new HashSet<SalesOrderHeader>();
        }

        /// <summary>
        /// Primary key for Address records.
        /// </summary>
        public int AddressId { get; set; }
        /// <summary>
        /// First street address line.
        /// </summary>
        public string AddressLine1 { get; set; } = null!;
        /// <summary>
        /// Second street address line.
        /// </summary>
        public string? AddressLine2 { get; set; }
        /// <summary>
        /// Name of the city.
        /// </summary>
        public string City { get; set; } = null!;
        /// <summary>
        /// Unique identification number for the state or province. Foreign key to StateProvince table.
        /// </summary>
        public int StateProvinceId { get; set; }
        /// <summary>
        /// Postal code for the street address.
        /// </summary>
        public string PostalCode { get; set; } = null!;
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        public Guid Rowguid { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public StateProvince StateProvince { get; set; } = null!;
        public ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        public ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddresses { get; set; }
        public ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddresses { get; set; }
    }
}

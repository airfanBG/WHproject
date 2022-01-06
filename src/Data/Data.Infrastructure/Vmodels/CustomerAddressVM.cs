using Data.Infrastructure.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Infrastructure.Vmodels
{
    public class CustomerAddressVM:IVmodel
    {
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
        /// Name of state or province.
        /// </summary>
        public string StateProvince { get; set; } = null!;
        public string CountryRegion { get; set; } = null!;
        /// <summary>
        /// Postal code for the street address.
        /// </summary>
        public string PostalCode { get; set; } = null!;
    }
}

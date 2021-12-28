using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Lookup table containing the types of business entity contacts.
    /// </summary>
    public class ContactType: BaseModel
    {
        public ContactType()
        {
            BusinessEntityContacts = new HashSet<BusinessEntityContact>();
        }

        /// <summary>
        /// Primary key for ContactType records.
        /// </summary>
        public int ContactTypeId { get; set; }
        /// <summary>
        /// Contact type description.
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; }
    }
}

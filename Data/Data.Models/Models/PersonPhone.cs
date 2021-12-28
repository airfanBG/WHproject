using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Telephone number and type of a person.
    /// </summary>
    public class PersonPhone : BaseModel
    {
        /// <summary>
        /// Business entity identification number. Foreign key to Person.BusinessEntityID.
        /// </summary>
        public int BusinessEntityId { get; set; }
        /// <summary>
        /// Telephone number identification number.
        /// </summary>
        public string PhoneNumber { get; set; } = null!;
        /// <summary>
        /// Kind of phone number. Foreign key to PhoneNumberType.PhoneNumberTypeID.
        /// </summary>
        public int PhoneNumberTypeId { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public Person BusinessEntity { get; set; } = null!;
        public PhoneNumberType PhoneNumberType { get; set; } = null!;
    }
}

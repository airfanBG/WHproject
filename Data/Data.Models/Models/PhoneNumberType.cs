using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Type of phone number of a person.
    /// </summary>
    public class PhoneNumberType : BaseModel
    {
        public PhoneNumberType()
        {
            PersonPhones = new HashSet<PersonPhone>();
        }

        /// <summary>
        /// Primary key for telephone number type records.
        /// </summary>
        public int PhoneNumberTypeId { get; set; }
        /// <summary>
        /// Name of the telephone number type
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public ICollection<PersonPhone> PersonPhones { get; set; }
    }
}

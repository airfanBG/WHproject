using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Cross-reference table mapping people to their credit card information in the CreditCard table. 
    /// </summary>
    public class PersonCreditCard : BaseModel
    {
        /// <summary>
        /// Business entity identification number. Foreign key to Person.BusinessEntityID.
        /// </summary>
        public int BusinessEntityId { get; set; }
        /// <summary>
        /// Credit card identification number. Foreign key to CreditCard.CreditCardID.
        /// </summary>
        public int CreditCardId { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public Person BusinessEntity { get; set; } = null!;
        public CreditCard CreditCard { get; set; } = null!;
    }
}

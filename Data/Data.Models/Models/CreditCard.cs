using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Customer credit card information.
    /// </summary>
    public class CreditCard:BaseModel
    {
        public CreditCard()
        {
            PersonCreditCards = new HashSet<PersonCreditCard>();
            SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }

        /// <summary>
        /// Primary key for CreditCard records.
        /// </summary>
        public int CreditCardId { get; set; }
        /// <summary>
        /// Credit card name.
        /// </summary>
        public string CardType { get; set; } = null!;
        /// <summary>
        /// Credit card number.
        /// </summary>
        public string CardNumber { get; set; } = null!;
        /// <summary>
        /// Credit card expiration month.
        /// </summary>
        public byte ExpMonth { get; set; }
        /// <summary>
        /// Credit card expiration year.
        /// </summary>
        public short ExpYear { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public ICollection<PersonCreditCard> PersonCreditCards { get; set; }
        public ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}

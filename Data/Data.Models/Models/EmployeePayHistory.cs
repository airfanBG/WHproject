using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Employee pay history.
    /// </summary>
    public class EmployeePayHistory : IBaseModel
    {
        /// <summary>
        /// Employee identification number. Foreign key to Employee.BusinessEntityID.
        /// </summary>
        public int BusinessEntityId { get; set; }
        /// <summary>
        /// Date the change in pay is effective
        /// </summary>
        public DateTime RateChangeDate { get; set; }
        /// <summary>
        /// Salary hourly rate.
        /// </summary>
        public decimal Rate { get; set; }
        /// <summary>
        /// 1 = Salary received monthly, 2 = Salary received biweekly
        /// </summary>
        public byte PayFrequency { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public Employee BusinessEntity { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Lookup table containing the departments within the Adventure Works Cycles company.
    /// </summary>
    public class Department : BaseModel
    {
        public Department()
        {
            EmployeeDepartmentHistories = new HashSet<EmployeeDepartmentHistory>();
        }

        /// <summary>
        /// Primary key for Department records.
        /// </summary>
        public short DepartmentId { get; set; }
        /// <summary>
        /// Name of the department.
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Name of the group to which the department belongs.
        /// </summary>
        public string GroupName { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
    }
}

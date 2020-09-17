using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialAPI.Models
{
    /// <summary>
    /// The model for the Household unit in the Financial Portal
    /// </summary>
    public class Household
    {
        /// <summary>
        /// The Primary Key of the Household
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User generated name of the Household
        /// </summary>
        public string HouseholdName { get; set; }
        /// <summary>
        /// Shown to new users of the Household when joining
        /// </summary>
        public string Greeting { get; set; }
        /// <summary>
        /// The time when the Household was created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Soft delete boolean value
        /// </summary>
        public bool IsDeleted { get; set; }
    }

}
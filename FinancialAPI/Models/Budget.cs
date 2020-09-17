using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialAPI.Models
{
    /// <summary>
    /// The model of the Budget unit in the Financial Portal
    /// </summary>
    public class Budget
    {
        /// <summary>
        /// The Primary Key of the Budget
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The Foreign Key of the Budget to the Household
        /// </summary>
        public int HouseholdId { get; set; }
        /// <summary>
        /// The owner of the Budget
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// The time when the Budget was created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// The name of the Budget
        /// </summary>
        public string BudgetName { get; set; }
        /// <summary>
        /// The current amount of the Budget in USD
        /// </summary>
        public decimal CurrentAmount { get; set; }
    }

}
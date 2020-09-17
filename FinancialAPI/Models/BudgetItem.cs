using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialAPI.Models
{
    /// <summary>
    /// The model for the Budget Item unit of the Financial Portal
    /// </summary>
    public class BudgetItem
    {
        /// <summary>
        /// The Primary Key of the Budget Item
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The Foreign Key of the Budget Item to the Budget
        /// </summary>
        public int BudgetId { get; set; }
        /// <summary>
        /// The time when the Budget Item was created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// The name of the Budget Item
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// The target amount of the Budget Item in USD
        /// </summary>
        public decimal TargetAmount { get; set; }
        /// <summary>
        /// The current amount contained within the Budget Item in USD
        /// </summary>
        public decimal CurrentAmount { get; set; }
        /// <summary>
        /// Soft delete boolean value
        /// </summary>
        public bool IsDeleted { get; set; }
        
    }

}
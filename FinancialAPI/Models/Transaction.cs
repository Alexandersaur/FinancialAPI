using FinancialAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialAPI.Models
{
    /// <summary>
    /// The model for the Transaction unit in the Financial Portal
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// The Primary Key of the Transaction
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The Foreign Key of the Transaction to the Account
        /// </summary>
        public int AccountId { get; set; }
        /// <summary>
        /// The Foreign Key of the Transaction to the Budget Item
        /// </summary>
        public int? BudgetItemId { get; set; }
        /// <summary>
        /// The owner of the Transaction
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// The type of Transaction
        /// </summary>
        public TransactionType TransactionType { get; set; }
        /// <summary>
        /// The time when the Transaction was created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// The total amount of the Transaction in USD
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Notes describing the Transaction
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// Soft delete boolean value
        /// </summary>
        public bool IsDeleted { get; set; }

    }
}
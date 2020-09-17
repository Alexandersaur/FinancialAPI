using FinancialAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialAPI.Models
{
    /// <summary>
    /// The model of the Bank Account in the Financial Portal
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// The Primary Key of the Bank Account
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The Foreign Key of the Bank Account to the Household
        /// </summary>
        public int? HouseholdId { get; set; }
        /// <summary>
        /// The owner of the Bank Account
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// The name of the Bank Account
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// The time when the Bank Account was created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// The starting balance of the Bank Account in USD
        /// </summary>
        public decimal StartingBalance { get; internal set; }
        /// <summary>
        /// The current balance of the Bank Account in USD
        /// </summary>
        public decimal CurrentBalance { get; set; }
        /// <summary>
        /// The warning balance of the Bank Account in USD
        /// </summary>
        public decimal WarningBalance { get; set; }
        /// <summary>
        /// Soft delete boolean value
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// The type of the Bank Account
        /// </summary>
        public AccountType AccountType { get; set; }
    }

}
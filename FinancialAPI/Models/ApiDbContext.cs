using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FinancialAPI.Models
{
    /// <summary>
    /// The model of API DbContext in the Financial Portal
    /// </summary>
    public class ApiDbContext : DbContext 
    {
        /// <summary>
        /// API DbContext information
        /// </summary>
        public ApiDbContext()
        : base("ApiConnection")
        {
        }

        //public DbSet<Household> Households { get; set; }

        //Here is where I add the code to call my various stored procs

        #region Get Commands
        /// <summary>
        /// Returns all Household information
        /// </summary>
        /// <returns>List of Household model</returns>
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await Database.SqlQuery<Household>("GetAllHouseholdData").ToListAsync();
        }
        /// <summary>
        /// Returns Household data for a single Household
        /// </summary>
        /// <param name="hhId">The Primary Key of the Household</param>
        /// <returns>Household model</returns>
        public async Task<Household> GetHouseholdDataById(int hhId)
        {
            return await Database.SqlQuery<Household>("GetHouseholdDataById @Id",
                new SqlParameter("Id", hhId)).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Returns all Transaction information
        /// </summary>
        /// <returns>List of Transaction model</returns>
        public async Task<List<Transaction>> GetAllTransactionData()
        {
            return await Database.SqlQuery<Transaction>("GetAllTransactionData").ToListAsync();
        }
        /// <summary>
        /// Returns Transaction information for a single Transaction
        /// </summary>
        /// <param name="trxId">The Primary Key of the Transaction</param>
        /// <returns>Transaction model</returns>
        public async Task<Transaction> GetTransactionDataById(int trxId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDataById @Id",
                new SqlParameter("Id", trxId)).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Returns all Bank Account information
        /// </summary>
        /// <returns>List of Bank Account model</returns>
        public async Task<List<BankAccount>> GetAllBankAccountData()
        {
            return await Database.SqlQuery<BankAccount>("GetAllBankAccountData").ToListAsync();
        }
        /// <summary>
        /// Returns Bank Account information for a single Bank Account
        /// </summary>
        /// <param name="baId">The Primary Key of the Bank Account</param>
        /// <returns>Bank Account model</returns>
        public async Task<BankAccount> GetBankAccountDataById(int baId)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountDataById @Id",
                new SqlParameter("Id", baId)).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Returns all Budget information 
        /// </summary>
        /// <returns>List of Budget model</returns>
        public async Task<List<Budget>> GetAllBudgetData()
        {
            return await Database.SqlQuery<Budget>("GetAllBudgetData").ToListAsync();
        }
        /// <summary>
        /// Retuns Budget information for a single Budget
        /// </summary>
        /// <param name="buId">The Primary Key of the Budget</param>
        /// <returns>Budget model</returns>
        public async Task<Budget> GetBudgetDataById(int buId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDataById @Id",
                new SqlParameter("Id", buId)).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Returns all Budget Item information
        /// </summary>
        /// <returns>List of Budget Item model</returns>
        public async Task<List<BudgetItem>> GetAllBudgetItemData()
        {
            return await Database.SqlQuery<BudgetItem>("GetAllBudgetItemData").ToListAsync();
        }
        /// <summary>
        /// Returns Budget Item information for a single Budget Item
        /// </summary>
        /// <param name="biId">Primary Key of the Budget Item</param>
        /// <returns>Busget Item model</returns>
        public async Task<BudgetItem> GetBudgetItemDataById(int biId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDataById @Id",
                new SqlParameter("Id", biId)).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Deletes a single Household
        /// </summary>
        /// <param name="id">Primary Key of the Household</param>
        /// <returns>Household model</returns>
        #endregion

        #region Delete Commands
        public int DeleteHouseholdDataById (int id)
        {
            return Database.ExecuteSqlCommand("DeleteHouseholdDataById @Id",
                new SqlParameter("Id", id));
        }
        /// <summary>
        /// Deletes a single Transaction
        /// </summary>
        /// <param name="id">Primary Key of the Transaction</param>
        /// <returns>Transaction model</returns>
        public int DeleteTransactionDataById(int id)
        {
            return Database.ExecuteSqlCommand("DeleteTransactionDataById @Id",
                new SqlParameter("Id", id));
        }
        /// <summary>
        /// Deletes a single Budget
        /// </summary>
        /// <param name="id">Primary Key of the Budget</param>
        /// <returns>Budget model</returns>
        public int DeleteBudgetDataById(int id)
        {
            return Database.ExecuteSqlCommand("DeleteBudgetDataById @Id",
                new SqlParameter("Id", id));
        }
        /// <summary>
        /// Deletes a single Budget Item
        /// </summary>
        /// <param name="id">Primary Key of the Budget Item</param>
        /// <returns>Budget Item model</returns>
        public int DeleteBudgetItemDataById(int id)
        {
            return Database.ExecuteSqlCommand("DeleteBudgetItemDataById @Id",
                new SqlParameter("Id", id));
        }
        /// <summary>
        /// Delete a single Bank Account
        /// </summary>
        /// <param name="id">Primary Key of the Bank Account</param>
        /// <returns>Bank Account model</returns>
        public int DeleteBankAccountDataById(int id)
        {
            return Database.ExecuteSqlCommand("DeleteBankAccountDataById @Id",
                new SqlParameter("Id", id));
        }
        #endregion

        #region Update Commands
        /// <summary>
        /// Update Household information
        /// </summary>
        /// <param name="HouseholdName">Name of the Household</param>
        /// <param name="Greeting">Greeting when joining the Household</param>
        /// <param name="Created">Time when Household was created</param>
        /// <param name="IsDeleted">Soft delete boolean</param>
        /// <returns>Household model</returns>
        public async Task<int> UpdateHouseholdDataById 
            (
            string HouseholdName, 
            string Greeting,
            DateTime Created,
            bool IsDeleted
            )
        {
            return await Database.ExecuteSqlCommandAsync
                (
                "UpdateHouseholdDataById" +
                "@HouseholdName" +
                "@Greeting",
                new SqlParameter("HouseholdName", HouseholdName),
                new SqlParameter("Greeting", Greeting),
                new SqlParameter("Created", Created),
                new SqlParameter("IsDeleted", IsDeleted)
                );
        }
        /// <summary>
        /// Update Bank Account information
        /// </summary>
        /// <param name="HouseholdId">Foreign Key of Household to Bank Account</param>
        /// <param name="OwnerId">Foreign Key of owner to Bank Account</param>
        /// <param name="AccountName">Name of Bank Account</param>
        /// <param name="Created">Time when Bank Account was created</param>
        /// <param name="StartingBalance">Starting amount of Bank Account in USD</param>
        /// <param name="CurrentBalance">Current amount of Bank Account in USD</param>
        /// <param name="WarningBalance">Warning amount of Bank Account in USD</param>
        /// <param name="IsDeleted">Soft delete boolean</param>
        /// <param name="AccountType">Bank Account type</param>
        /// <returns>Bank Account model</returns>
        public async Task<int> UpdateBankAccountDataById
            (
            int HouseholdId, 
            string OwnerId, 
            string AccountName, 
            DateTime Created, 
            decimal StartingBalance, 
            decimal CurrentBalance, 
            decimal WarningBalance, 
            bool IsDeleted, 
            int AccountType 
            )
        {
            return await Database.ExecuteSqlCommandAsync
                (
                "UpdateBankAccountDataById" +
                "@HouseholdId" +
                "@OwnerId" +
                "@AccountName" +
                "@Created" +
                "@StartingBalance" +
                "@CurrentBalance" +
                "@WarningBalance" +
                "@IsDeleted" +
                "@AccountType",
                new SqlParameter("HouseholdId", HouseholdId),
                new SqlParameter("OwnerId", OwnerId),
                new SqlParameter("AccountName", AccountName),
                new SqlParameter("Created", Created),
                new SqlParameter("StartingBalance", StartingBalance),
                new SqlParameter("CurrentBalance", CurrentBalance),
                new SqlParameter("WarningBalance", WarningBalance),
                new SqlParameter("IsDeleted", IsDeleted),
                new SqlParameter("AccountType", AccountType)
                );
        }
        /// <summary>
        /// Update Budget information
        /// </summary>
        /// <param name="HouseholdId">Foreign Key of Household to Budget</param>
        /// <param name="OwnerId">Foreign Key of Owner to Budget</param>
        /// <param name="Created">Time when Budget was created</param>
        /// <param name="BudgetName">Name of Budget</param>
        /// <param name="CurrentAmount">Current amount of Budget in USD</param>
        /// <returns>Budget model</returns>
        public async Task<int> UpdateBudgetDataById
            (
            int HouseholdId,
            string OwnerId,
            DateTime Created,
            string BudgetName,
            decimal CurrentAmount
            )
        {
            return await Database.ExecuteSqlCommandAsync
                (
                "UpdateBudgetDataById" +
                "@HouseholdId" +
                "@OwnerId" +
                "@Created" +
                "@BudgetName" +
                "@CurrentAmount",
                new SqlParameter("HouseholdId", HouseholdId),
                new SqlParameter("OwnerId", OwnerId),
                new SqlParameter("Created", Created),
                new SqlParameter("BudgetName", BudgetName),
                new SqlParameter("CurrentAmount", CurrentAmount)
                );
        }
        /// <summary>
        /// Update Budget Item information
        /// </summary>
        /// <param name="BudgetId">Foreign Key of Budget to Budget Item</param>
        /// <param name="Created">Time when Budget Item was created</param>
        /// <param name="ItemName">Name of Budget Item</param>
        /// <param name="TargetAmount">Target amount of Budget Item in USD</param>
        /// <param name="CurrentAmount">Current amount of Budget Item in USD</param>
        /// <param name="IsDeleted">Soft delete boolean</param>
        /// <returns>Budget model</returns>
        public async Task<int> UpdateBudgetItemDataById
            (
            int BudgetId,
            DateTime Created,
            string ItemName,
            decimal TargetAmount,
            decimal CurrentAmount,
            bool IsDeleted
            )
        {
            return await Database.ExecuteSqlCommandAsync
                (
                "UpdateBudgetItemDataById" +
                "@BudgetId" +
                "@Created" +
                "@ItemName" +
                "@TargetAmount" +
                "@CurrentAmount" +
                "@IsDeleted",
                new SqlParameter("BudgetId", BudgetId),
                new SqlParameter("Created", Created),
                new SqlParameter("ItemName", ItemName),
                new SqlParameter("TargetAmount", TargetAmount),
                new SqlParameter("CurrentAmount", CurrentAmount),
                new SqlParameter("IsDeleted", IsDeleted)
                );
        }
        /// <summary>
        /// Update Transaction information
        /// </summary>
        /// <param name="AccountId">Foreign Key of Account to Transaction</param>
        /// <param name="BudgetItemId">Foreign Key of Budget Item to Transaction</param>
        /// <param name="OwnerId">Foreign Key of Owner to Transaction</param>
        /// <param name="TransactionType">Type of Transaction</param>
        /// <param name="Created">Time when Transaction was created</param>
        /// <param name="Amount">Amount of Transaction in USD</param>
        /// <param name="Memo">Memo regarding Transaction information</param>
        /// <param name="IsDeleted">Soft delete boolean</param>
        /// <returns>Transaction model</returns>
        public async Task<int> UpdateTransactionDataById
            (
            int AccountId,
            int BudgetItemId,
            string OwnerId,
            int TransactionType,
            DateTime Created,
            decimal Amount,
            string Memo,
            bool IsDeleted
            )
        {
            return await Database.ExecuteSqlCommandAsync
                (
                "UpdateTransactionDataById" +
                "@AccountId" +
                "@BudgetItemId" +
                "@OwnerId" +
                "@TransactionType" +
                "@Created" +
                "@Amount" +
                "@Memo" +
                "@IsDeleted",
                new SqlParameter("AccountId", AccountId),
                new SqlParameter("BudgetItemId", BudgetItemId),
                new SqlParameter("OwnerId", OwnerId),
                new SqlParameter("TransactionType", TransactionType),
                new SqlParameter("Created", Created),
                new SqlParameter("Amount", Amount),
                new SqlParameter("Memo", Memo),
                new SqlParameter("IsDeleted", IsDeleted)
                );
        }
        #endregion
    }
}
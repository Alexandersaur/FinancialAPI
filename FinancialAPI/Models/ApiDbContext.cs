using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FinancialAPI.Models
{
    public class ApiDbContext : DbContext 
    {
        public ApiDbContext()
        : base("ApiConnection")
        {
        }

        //public DbSet<Household> Households { get; set; }

        //Here is where I add the code to call my various stored procs
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await Database.SqlQuery<Household>("GetAllHouseholdData").ToListAsync();
        }

        public async Task<Household> GetHouseholdDataById(int hhId)
        {
            return await Database.SqlQuery<Household>("GetHouseholdDataById @Id",
                new SqlParameter("Id", hhId)).FirstOrDefaultAsync();
        }
        public async Task<List<Transaction>> GetAllTransactionData()
        {
            return await Database.SqlQuery<Transaction>("GetAllTransactionData").ToListAsync();
        }

        public async Task<Transaction> GetTransactionDataById(int trxId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDataById @Id",
                new SqlParameter("Id", trxId)).FirstOrDefaultAsync();
        }
        public async Task<List<BankAccount>> GetAllBankAccountData()
        {
            return await Database.SqlQuery<BankAccount>("GetAllBankAccountData").ToListAsync();
        }

        public async Task<BankAccount> GetBankAccountDataById(int baId)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountDataById @Id",
                new SqlParameter("Id", baId)).FirstOrDefaultAsync();
        }
        public async Task<List<Budget>> GetAllBudgetData()
        {
            return await Database.SqlQuery<Budget>("GetAllBudgetData").ToListAsync();
        }

        public async Task<Budget> GetBudgetDataById(int buId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDataById @Id",
                new SqlParameter("Id", buId)).FirstOrDefaultAsync();
        }
        public async Task<List<BudgetItem>> GetAllBudgetItemData()
        {
            return await Database.SqlQuery<BudgetItem>("GetAllBudgetItemData").ToListAsync();
        }

        public async Task<BudgetItem> GetBudgetItemDataById(int biId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDataById @Id",
                new SqlParameter("Id", biId)).FirstOrDefaultAsync();
        }

    }
}
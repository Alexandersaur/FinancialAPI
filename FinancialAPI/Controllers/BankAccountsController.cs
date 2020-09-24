using FinancialAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinancialAPI.Controllers
{
    /// <summary>
    /// Bank Account information
    /// </summary>
    [RoutePrefix("api/BankAccounts")]
    public class BankAccountsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        /// <summary>
        /// Returns information for all Bank Accounts
        /// </summary>
        /// <returns>All Bank Account model</returns>
        [Route("GetAllBankAccountData")]
        public async Task<List<BankAccount>> GetAllBankAccountData()
        {
            return await db.GetAllBankAccountData();
        }
        /// <summary>
        /// Returns information for all Bank Accounts as JSON
        /// </summary>
        /// <returns>All Bank Account model in JSON</returns>
        [Route("GetAllBankAccountData/json")]
        public async Task<IHttpActionResult> GetAllBankAccountDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBankAccountData());
            return Ok(json);
        }
        /// <summary>
        /// Returns information for a single Bank Account
        /// </summary>
        /// <param name="id">The Primary Key of the Bank Account</param>
        /// <returns>Single Bank Account model</returns>
        [Route("GetDataForSingleBankAccount")]
        public async Task<BankAccount> GetBankAccountDataById(int id)
        {
            return await db.GetBankAccountDataById(id);
        }
        /// <summary>
        /// Returns information for a single Bank Account as JSON
        /// </summary>
        /// <param name="id">The Primary Key of the Bank Account</param>
        /// <returns>Single Bank Account model in JSON</returns>
        [Route("GetDataForSingleBankAccount/json")]
        public async Task<IHttpActionResult> GetBankAccountDataByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBankAccountDataById(id)));
        }
        /// <summary>
        /// Update Bank Account information
        /// </summary>
        /// <param name="HouseholdId">The Foreign Key of the Household to the Bank Account</param>
        /// <param name="OwnerId">The Foriegn Key of the Owner to the Bank Account</param>
        /// <param name="AccountName">The name of the Bank Account</param>
        /// <param name="Created">The time when the Bank Account was created</param>
        /// <param name="StartingBalance">The starting balance of the Bank Account in USD</param>
        /// <param name="CurrentBalance">The current balance of the Bank Account in USD</param>
        /// <param name="WarningBalance">The warning balance of the Bank Account in USD</param>
        /// <param name="IsDeleted">Soft delete boolean</param>
        /// <param name="AccountType">The type of the Bank Account</param>
        /// <returns>Bank Account model</returns>
        [Route("UpdateBankAccountDataById")]
        [HttpPut]
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
            return await db.UpdateBankAccountDataById(HouseholdId, OwnerId, AccountName, Created, StartingBalance, CurrentBalance, WarningBalance, IsDeleted, AccountType);
        }
        /// <summary>
        /// Delete existing Bank Account
        /// </summary>
        /// <param name="id">The Primary Key of the Bank Account to be deleted</param>
        [Route("DeleteBankAccountDataById")]
        public int DeleteBankAccountDataById(int id)
        {
            return db.DeleteBankAccountDataById(id);
        }
    }
}

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
    /// Transaction information
    /// </summary>
    [RoutePrefix("api/Transactions")]
    public class TransactionsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        /// <summary>
        /// Returns information for all Transactions
        /// </summary>
        /// <returns>All Transactions model</returns>
        [Route("GetAllTransactionData")]
        public async Task<List<Transaction>> GetAllTransactionData()
        {
            return await db.GetAllTransactionData();
        }
        /// <summary>
        /// Returns information for all Transactions in JSON
        /// </summary>
        /// <returns>All Transactions model in JSON</returns>
        [Route("GetAllTransactionData/json")]
        public async Task<IHttpActionResult> GetAllTransactionDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllTransactionData());
            return Ok(json);
        }
        /// <summary>
        /// Returns information for a single Transaction
        /// </summary>
        /// <param name="id">The Primary Key of the Transaction</param>
        /// <returns>Single Transaction model</returns>
        [Route("GetDataForSingleTransaction")]
        public async Task<Transaction> GetTransactionDataById(int id)
        {
            return await db.GetTransactionDataById(id);
        }
        /// <summary>
        /// Returns information for a single Transaction in JSON
        /// </summary>
        /// <param name="id">The Primary Key of the Transaction</param>
        /// <returns>Single Transaction model in JSON</returns>
        [Route("GetDataForSingleTransaction/json")]
        public async Task<IHttpActionResult> GetTransactionDataByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetTransactionDataById(id)));
        }
        /// <summary>
        /// Update Transaction information
        /// </summary>
        /// <param name="AccountId">The Foreign Key of the Account to the Transaction</param>
        /// <param name="BudgetItemId">The Foreign Key of the Budget Item to the Transaction</param>
        /// <param name="OwnerId">The Foreign Key of the Owner to the Transaction</param>
        /// <param name="TransactionType">The type of the Transaction</param>
        /// <param name="Created">The time when the Transaction was created</param>
        /// <param name="Amount">The amount of the Transaction in USD</param>
        /// <param name="Memo">Memo regarding Transaction information</param>
        /// <param name="IsDeleted">Soft delete boolean</param>
        /// <returns>Transaction model</returns>
        [Route("UpdateTransactionDataById")]
        [HttpPut]
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
            return await db.UpdateTransactionDataById(AccountId, BudgetItemId, OwnerId, TransactionType, Created, Amount, Memo, IsDeleted);
        }
        /// <summary>
        /// Delete existing Transaction 
        /// </summary>
        /// <param name="id">The Primary Key of the Transaction to be deleted </param>
        [Route("DeleteTransactionDataById")]
        public int DeleteTransactionDataById(int id)
        {
            return db.DeleteTransactionDataById(id);
        }
    }
}


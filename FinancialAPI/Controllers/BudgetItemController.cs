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
    /// Budget Item information
    /// </summary>
    [RoutePrefix("api/BudgetItems")]
    public class BudgetItemController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        /// <summary>
        /// Returns information for all Budget Items
        /// </summary>
        /// <returns>All Budget Item model</returns>
        [Route("GetAllBudgetItemData")]
        public async Task<List<BudgetItem>> GetAllBudgetItemData()
        {
            return await db.GetAllBudgetItemData();
        }
        /// <summary>
        /// Returns information for all Budget Items in JSON
        /// </summary>
        /// <returns>All Budget Items in JSON</returns>
        [Route("GetAllBudgetItemData/json")]
        public async Task<IHttpActionResult> GetAllBudgetItemDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBudgetItemData());
            return Ok(json);
        }
        /// <summary>
        /// Returns information for a single Budget Item
        /// </summary>
        /// <param name="id">The Primary Key of the Budget Item</param>
        /// <returns>Single Budget Item model</returns>
        [Route("GetDataForSingleBudgetItem")]
        public async Task<BudgetItem> GetBudgetItemDataById(int id)
        {
            return await db.GetBudgetItemDataById(id);
        }
        /// <summary>
        /// Returns information for a single Budget Item in JSON
        /// </summary>
        /// <param name="id">The Primary Key of the Budget Item</param>
        /// <returns>Single Budget Item model in JSON</returns>
        [Route("GetDataForSingleBudgetItem/json")]
        public async Task<IHttpActionResult> GetBudgetDataItemByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetItemDataById(id)));
        }
        /// <summary>
        /// Update Budget Item information
        /// </summary>
        /// <param name="BudgetId">The Foreign Key of the Budget to the Budget Item</param>
        /// <param name="Created">The time when the Budget Item was created</param>
        /// <param name="ItemName">The name of the Budget Item</param>
        /// <param name="TargetAmount">The target amount of the Budget Item in USD</param>
        /// <param name="CurrentAmount">The current amount of the Budget Item in USD</param>
        /// <param name="IsDeleted">Soft delete boolean</param>
        /// <returns>Budget Item model</returns>
        [Route("UpdateBudgetItemDataById")]
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
            return await db.UpdateBudgetItemDataById(BudgetId, Created, ItemName, TargetAmount, CurrentAmount, IsDeleted);
        }
        /// <summary>
        /// Delete existing Budget Item
        /// </summary>
        /// <param name="id">The Primary Key of the Budget Item to be deleted</param>
        [Route("DeleteBudgetItemDataById")]
        public int DeleteBudgetItemDataById(int id)
        {
            return db.DeleteBudgetItemDataById(id);
        }
    }
}

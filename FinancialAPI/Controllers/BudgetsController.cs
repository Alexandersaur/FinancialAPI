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
    /// Budget information
    /// </summary>
    [RoutePrefix("api/Budgets")]
    public class BudgetsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        /// <summary>
        /// Returns information for all Budgets
        /// </summary>
        /// <returns>All Budget model</returns>
        [Route("GetAllBudgetData")]
        public async Task<List<Budget>> GetAllBudgetData()
        {
            return await db.GetAllBudgetData();
        }
        /// <summary>
        /// Returns information for all Budgets in JSON
        /// </summary>
        /// <returns>All Budget model in JSON</returns>
        [Route("GetAllBudgetData/json")]
        public async Task<IHttpActionResult> GetAllBudgetDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBudgetData());
            return Ok(json);
        }
        /// <summary>
        /// Returs information for a single Budget
        /// </summary>
        /// <param name="id">The Primary Key for the Budget</param>
        /// <returns>Single Budget model</returns>
        [Route("GetDataForSingleBudget")]
        public async Task<Budget> GetBudgetDataById(int id)
        {
            return await db.GetBudgetDataById(id);
        }
        /// <summary>
        /// Returns information for a single Budget in JSON
        /// </summary>
        /// <param name="id">The Primary Key of the Budget</param>
        /// <returns>Single Budget model in JSON</returns>
        [Route("GetDataForSingleBudget/json")]
        public async Task<IHttpActionResult> GetBudgetDataByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetDataById(id)));
        }
        /// <summary>
        /// Update Budget information
        /// </summary>
        /// <param name="HouseholdId">The Foreign Key of the Household to the Budget</param>
        /// <param name="OwnerId">The Foreign Key of the Owner to the Budget</param>
        /// <param name="Created">The time when the Budget was created</param>
        /// <param name="BudgetName">The name of the Budget</param>
        /// <param name="CurrentAmount">The current amount of the Budget Item in USD</param>
        /// <returns>Budget model</returns>
        [Route("UpdateBudgetDataById")]
        public async Task<int> UpdateBudgetDataById
            (
            int HouseholdId,
            string OwnerId,
            DateTime Created,
            string BudgetName,
            decimal CurrentAmount
            )
        {
            return await db.UpdateBudgetDataById(HouseholdId, OwnerId, Created, BudgetName, CurrentAmount);
        }
        /// <summary>
        /// Delete existing Budget 
        /// </summary>
        /// <param name="id">The Primary Key of the Budget to be deleted </param>
        [Route("DeleteBudgetDataById")]
        public int DeleteBudgetDataById(int id)
        {
            return db.DeleteBudgetDataById(id);
        }
    }
}

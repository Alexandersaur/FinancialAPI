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
    /// Household information
    /// </summary>
    [RoutePrefix("api/Households")]
    public class HouseholdsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        /// <summary>
        /// Returns information for all Households
        /// </summary>
        /// <returns>All Household model</returns>
        /// <remarks>Testing purposes</remarks>
        [Route("GetAllHouseholdData")]
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await db.GetAllHouseholdData();
        }
        /// <summary>
        /// Returns information for all Households as JSON
        /// </summary>
        /// <returns>All Household model as JSON</returns>
        [Route("GetAllHouseholdData/json")]
        public async Task<IHttpActionResult> GetAllHouseholdDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllHouseholdData());
            return Ok(json);
        }
        /// <summary>
        /// Returns the information for a single Household
        /// </summary>
        /// <param name="id">The Primary Key of the Household you want to view</param>
        /// <returns>Single Household model</returns>
        [Route("GetDataForSingleHousehold")]
        public async Task<Household> GetHouseholdDataById(int id)
        {
            return await db.GetHouseholdDataById(id);
        }
        /// <summary>
        /// Retruns single Household information in JSON
        /// </summary>
        /// <param name="id">The Primary Key of the Household you want to view</param>
        /// <returns>Single Household model in JSON</returns>
        [Route("GetDataForSingleHousehold/json")]
        public async Task<IHttpActionResult> GetHouseholdDataByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetHouseholdDataById(id)));
        }
        /// <summary>
        /// Update Household information
        /// </summary>
        /// <param name="HouseholdName">The name of the Household</param>
        /// <param name="Greeting">The greeting when joining the Household</param>
        /// <param name="Created">The time when the Budget was created</param>
        /// <param name="IsDeleted">Soft delete boolean</param>
        /// <returns>Household model</returns>
        [Route("UpdateHouseholdDataById")]
        public async Task<int> UpdateHouseholdDataById
            (
            string HouseholdName,
            string Greeting,
            DateTime Created,
            bool IsDeleted
            )
        {
            return await db.UpdateHouseholdDataById(HouseholdName, Greeting, Created, IsDeleted);
        }
        /// <summary>
        /// Delete existing Household
        /// </summary>
        /// <param name="id">The ID of the Household to be deleted</param>
        [HttpDelete]
        [Route("DeleteHouseholdDataById")]
        public int DeleteHouseholdDataById(int id)
        {
            return db.DeleteHouseholdDataById(id);
        }
    }
}

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
    [RoutePrefix("api/Households")]
    public class HouseholdsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        [Route("GetAllHouseholdData")]
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await db.GetAllHouseholdData();
        }

        [Route("GetAllHouseholdData/json")]
        public async Task<IHttpActionResult> GetAllHouseholdDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllHouseholdData());
            return Ok(json);
        }

        [Route("GetDataForSingleHousehold")]
        public async Task<Household> GetHouseholdDataById(int id)
        {
            return await db.GetHouseholdDataById(id);
        }

        [Route("GetDataForSingleHousehold/json")]
        public async Task<IHttpActionResult> GetHouseholdDataByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetHouseholdDataById(id)));
        }
    }
}

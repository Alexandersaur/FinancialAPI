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
    [RoutePrefix("api/BudgetItems")]
    public class BudgetItemController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        [Route("GetAllBudgetItemData")]
        public async Task<List<BudgetItem>> GetAllBudgetItemData()
        {
            return await db.GetAllBudgetItemData();
        }

        [Route("GetAllBudgetItemData/json")]
        public async Task<IHttpActionResult> GetAllBudgetItemDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBudgetItemData());
            return Ok(json);
        }

        [Route("GetDataForSingleBudgetItem")]
        public async Task<BudgetItem> GetBudgetItemDataById(int id)
        {
            return await db.GetBudgetItemDataById(id);
        }

        [Route("GetDataForSingleBudgetItem/json")]
        public async Task<IHttpActionResult> GetBudgetDataItemByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetItemDataById(id)));
        }
    }
}

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
    [RoutePrefix("api/Budgets")]
    public class BudgetsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        [Route("GetAllBudgetData")]
        public async Task<List<Budget>> GetAllBudgetData()
        {
            return await db.GetAllBudgetData();
        }

        [Route("GetAllBudgetData/json")]
        public async Task<IHttpActionResult> GetAllBudgetDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBudgetData());
            return Ok(json);
        }

        [Route("GetDataForSingleBudget")]
        public async Task<Budget> GetBudgetDataById(int id)
        {
            return await db.GetBudgetDataById(id);
        }

        [Route("GetDataForSingleBudget/json")]
        public async Task<IHttpActionResult> GetBudgetDataByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetDataById(id)));
        }
    }
}

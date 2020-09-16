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
    [RoutePrefix("api/Transactions")]
    public class TransactionsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        [Route("GetAllTransactionData")]
        public async Task<List<Transaction>> GetAllTransactionData()
        {
            return await db.GetAllTransactionData();
        }

        [Route("GetAllTransactionData/json")]
        public async Task<IHttpActionResult> GetAllTransactionDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllTransactionData());
            return Ok(json);
        }

        [Route("GetDataForSingleTransaction")]
        public async Task<Transaction> GetTransactionDataById(int id)
        {
            return await db.GetTransactionDataById(id);
        }

        [Route("GetDataForSingleTransaction/json")]
        public async Task<IHttpActionResult> GetTransactionDataByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetTransactionDataById(id)));
        }
    }
}


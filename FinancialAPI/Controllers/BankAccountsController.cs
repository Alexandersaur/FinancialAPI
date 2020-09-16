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
    [RoutePrefix("api/BankAccounts")]
    public class BankAccountsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        [Route("GetAllBankAccountData")]
        public async Task<List<BankAccount>> GetAllBankAccountData()
        {
            return await db.GetAllBankAccountData();
        }

        [Route("GetAllBankAccountData/json")]
        public async Task<IHttpActionResult> GetAllBankAccountDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBankAccountData());
            return Ok(json);
        }

        [Route("GetDataForSingleBankAccount")]
        public async Task<BankAccount> GetBankAccountDataById(int id)
        {
            return await db.GetBankAccountDataById(id);
        }

        [Route("GetDataForSingleBankAccount/json")]
        public async Task<IHttpActionResult> GetBankAccountDataByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBankAccountDataById(id)));
        }
    }
}

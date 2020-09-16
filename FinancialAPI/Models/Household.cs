using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialAPI.Models
{
    public class Household
    {
        public int Id { get; set; }
        public string HouseholdName { get; set; }
        public string Greeting { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }
    }

}
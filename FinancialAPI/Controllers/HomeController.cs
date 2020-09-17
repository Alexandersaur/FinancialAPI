using FinancialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialAPI.Controllers
{
    /// <summary>
    /// Home information
    /// </summary>
    public class HomeController : Controller
    {
        private ApiDbContext db = new ApiDbContext();
        /// <summary>
        /// Home page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //public ActionResult TestConnection()
        //{
        //    return View(db.Households.ToList());
        //}
    }
}

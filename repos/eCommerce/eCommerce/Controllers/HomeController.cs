using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Models;

namespace eCommerce.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            using (DBmodel db = new DBmodel())
            {


                return View(db.products.ToList());
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Indexmain()
        {
            using (DBmodel db = new DBmodel())
            {


                return View(db.products.ToList());
            }
        }

    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View("OurCompanyProducts");
        }

        public ActionResult Contacts()
        {
            return View();
        }
    }
}
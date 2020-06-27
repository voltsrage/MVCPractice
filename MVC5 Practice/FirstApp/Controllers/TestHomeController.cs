using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApp.Controllers
{
    public class TestHomeController : Controller
    {
        // GET: TestHome
        public ActionResult Index(string value)
        {
            if(value == "sample")
            {
                string fileName = "~/"+value + ".pdf";
                return File(fileName, "application/pdf");
            }
            else if(value == "gotoabout")
            {
                return RedirectToAction("About");
            }
            else if (value == "login")
            {
                return RedirectToAction("Login");
            }
            else
            {
                return Content("You entered: " + value);
            }
           
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            ViewBag.Phone = "886-111-111-1111";
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFoirstApproachExample.Filters;

namespace EFDbFoirstApproachExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [MyActionFilter]
        [MyResultFilter]
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            return View();
        }
    }
}
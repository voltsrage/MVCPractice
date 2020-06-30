using EFDbFoirstApproachExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDbFoirstApproachExample.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            TrentBasDB db = new TrentBasDB();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}
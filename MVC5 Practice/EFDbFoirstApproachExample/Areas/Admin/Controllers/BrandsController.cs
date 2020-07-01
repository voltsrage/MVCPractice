using EFDbFoirstApproachExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDbFoirstApproachExample.Areas.Admin.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Admin/Brands
        public ActionResult Index()
        {
            TrentBasDbContext db = new TrentBasDbContext();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}
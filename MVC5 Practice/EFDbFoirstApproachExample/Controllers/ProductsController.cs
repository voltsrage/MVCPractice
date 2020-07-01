using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFoirstApproachExample.Models;

namespace EFDbFoirstApproachExample.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            TrentBasDbContext db = new TrentBasDbContext();
            List < Product > products = db.Products.ToList();
            return View(products);
        }
    }
}
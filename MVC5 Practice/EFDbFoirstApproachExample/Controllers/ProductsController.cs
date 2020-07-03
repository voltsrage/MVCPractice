using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrentBas.DomainModels.Models;
using TrentBas.DataLayer;
using EFDbFoirstApproachExample.Filters;

namespace EFDbFoirstApproachExample.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [MyAuthenticationFilter]
        [CustomerAuthorization]
        [MyActionFilter]       
        public ActionResult Index()
        {

            TrentBasDbContext db = new TrentBasDbContext();
            List < Product > products = db.Products.ToList();
            return View(products);
        }

        [ChildActionOnly]
        public ActionResult DisplaySingleProduct(Product p)
        {
            return PartialView("MyProduct", p);
        }
    }
}
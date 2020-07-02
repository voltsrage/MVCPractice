using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFoirstApproachExample.Models;
using EFDbFoirstApproachExample.Filters;

namespace EFDbFoirstApproachExample.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [MyAuthenticationFilter]
        [CustomerAuthorization]
        [ManagerAuthorization]
        [AdminAuthorization]        
        public ActionResult Index()
        {

            TrentBasDbContext db = new TrentBasDbContext();
            List < Product > products = db.Products.ToList();
            return View(products);
        }
    }
}
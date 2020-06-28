using EFDbFoirstApproachExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDbFoirstApproachExample.Controllers
{
    public class ProductsController : Controller
    {
        

        // GET: Products
        public ActionResult Index(string search = "")
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            ViewBag.search = search;
            List<Product> products = db.Products.Where(p => p.ProductName.Contains(search)).ToList();
            return View(products);
        }

        public ActionResult Details(long id)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product product = db.Products.Where(p => p.ProductID == id).FirstOrDefault();
            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
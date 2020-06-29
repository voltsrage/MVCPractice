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
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
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

        public ActionResult Edit(long id)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            Product existingProduct = db.Products.Where(p => p.ProductID == id).FirstOrDefault();

            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product existingProduct = db.Products.Where(prod => prod.ProductID == p.ProductID).FirstOrDefault();

            existingProduct.ProductName = p.ProductName;
            existingProduct.Price = p.Price;
            existingProduct.DateOfPurchase = p.DateOfPurchase;
            existingProduct.CategoryID = p.CategoryID;
            existingProduct.BrandID = p.BrandID;
            existingProduct.AvailabilityStatus = p.AvailabilityStatus;
            existingProduct.Active = p.Active;

            db.SaveChanges();
            return RedirectToAction("Index","Products");
        }

        public ActionResult Delete(long id)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product deleteProduct = db.Products.Where(p => p.ProductID == id).FirstOrDefault();

            return View(deleteProduct);
        }

        [HttpPost]
        public ActionResult Delete(Product p,long id)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product deleteProduct = db.Products.Where(prod => prod.ProductID == id).FirstOrDefault();

            db.Products.Remove(deleteProduct);
            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}
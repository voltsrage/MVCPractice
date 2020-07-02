using EFDbFoirstApproachExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFoirstApproachExample.Filters;

namespace EFDbFoirstApproachExample.Areas.Manager.Controllers
{
    [ManagerAuthorization]
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(string search = "", string SortColumn = "ProductName", string IconClass = "fa-sort-asc", int PageNo = 1)
        {
            TrentBasDbContext db = new TrentBasDbContext();
            ViewBag.search = search;
            List<Product> products = db.Products.Where(p => p.ProductName.Contains(search)).ToList();

            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            if (ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(p => p.ProductID).ToList();
                else
                    products = products.OrderByDescending(p => p.ProductID).ToList();
            }
            else if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(p => p.ProductName).ToList();
                else
                    products = products.OrderByDescending(p => p.ProductName).ToList();
            }
            else if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(p => p.Price).ToList();
                else
                    products = products.OrderByDescending(p => p.Price).ToList();
            }
            else if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(p => p.DateOfPurchase).ToList();
                else
                    products = products.OrderByDescending(p => p.DateOfPurchase).ToList();
            }
            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(p => p.AvailabilityStatus).ToList();
                else
                    products = products.OrderByDescending(p => p.AvailabilityStatus).ToList();
            }
            else if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(p => p.Category.CategoryName).ToList();
                else
                    products = products.OrderByDescending(p => p.Category.CategoryName).ToList();
            }
            else if (ViewBag.SortColumn == "BrandID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(p => p.Brand.BrandName).ToList();
                else
                    products = products.OrderByDescending(p => p.Brand.BrandName).ToList();
            }

            //Paging

            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling((Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage))));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;

            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;

            products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return View(products);
        }

        public ActionResult Details(long id)
        {
            TrentBasDbContext db = new TrentBasDbContext();
            Product product = db.Products.Where(p => p.ProductID == id).FirstOrDefault();
            return View(product);
        }

        public ActionResult Create()
        {
            TrentBasDbContext db = new TrentBasDbContext();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            TrentBasDbContext db = new TrentBasDbContext();
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    p.Photo = base64String;
                }
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(long id)
        {
            TrentBasDbContext db = new TrentBasDbContext();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            Product existingProduct = db.Products.Where(p => p.ProductID == id).FirstOrDefault();

            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            TrentBasDbContext db = new TrentBasDbContext();
            Product existingProduct = db.Products.Where(prod => prod.ProductID == p.ProductID).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    if (file.ContentLength >= 1)
                    {
                        var imgBytes = new Byte[file.ContentLength];
                        file.InputStream.Read(imgBytes, 0, file.ContentLength);
                        var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                        existingProduct.Photo = base64String;
                    }

                    existingProduct.ProductName = p.ProductName;
                    existingProduct.Price = p.Price;
                    existingProduct.DateOfPurchase = p.DateOfPurchase;
                    existingProduct.CategoryID = p.CategoryID;
                    existingProduct.BrandID = p.BrandID;
                    existingProduct.AvailabilityStatus = p.AvailabilityStatus;
                    existingProduct.Active = p.Active;

                    db.SaveChanges();
                }



                return RedirectToAction("Index", "Products");
            }
            else
            {
                return View();
            }
        }       

        
    }
}
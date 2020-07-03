using EFDbFoirstApproachExample.Filters;
using TrentBas.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrentBas.DataLayer;
using TrentBas.ServiceContracts;
using TrentBas.ServiceLayer;


namespace EFDbFoirstApproachExample.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductsController : Controller
    {
        TrentBasDbContext db;
        IService<Product> prodService;
        
        public ProductsController(ProductService ProductService)
        {
            this.db = new TrentBasDbContext();
            this.prodService = ProductService;
        }
       
        // GET: Products
        public ActionResult Index(string search = "", string SortColumn = "ProductName", string IconClass = "fa-sort-asc", int PageNo = 1)
        {
            TrentBasDbContext db = new TrentBasDbContext();
            ViewBag.search = search;
            List<Product> products = prodService.SearchT(search);

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
            Product product = prodService.GetTByTID(id);
            return View(product);
        }

        public ActionResult Create()
        {           
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p)
        {            
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
                prodService.InsertT(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(long id)
        {            
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            Product existingProduct = prodService.GetTByTID(id);
            return View(existingProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

                    prodService.UpdateT(existingProduct);
                }


                
                return RedirectToAction("Index", "Products");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(long id)
        {
            Product deleteProduct = prodService.GetTByTID(id);

            return View(deleteProduct);
        }

        [HttpPost]
        public ActionResult Delete(Product p, long id)
        {

            prodService.Delete(id);
            return RedirectToAction("Index", "Products");
        }
    }
}
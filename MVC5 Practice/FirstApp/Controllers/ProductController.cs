using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstApp.Models;

namespace FirstApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = new List<Product>()
            {
                new Product() {SubjectId = "Eng",SubjectName = "English",PassingGrade=80},
                new Product() {SubjectId = "Math",SubjectName = "Mathematics",PassingGrade=70},
                new Product() {SubjectId = "Ch",SubjectName = "Chinese",PassingGrade=65}
            };
            ViewBag.products = products;
            return View();
        }

        public ActionResult Details(string id)
        {
            List<Product> products = new List<Product>()
            {
                new Product() {SubjectId = "Eng",SubjectName = "English",PassingGrade=80},
                new Product() {SubjectId = "Math",SubjectName = "Mathematics",PassingGrade=70},
                new Product() {SubjectId = "Ch",SubjectName = "Chinese",PassingGrade=65}
            };
            Product matchingSubject = null;
            foreach(var item in products)
            {
                if(item.SubjectId == id)
                {
                    matchingSubject = item;
                }
            }
            ViewBag.MatchingSubject = matchingSubject;

            return View();
        }
    }
}
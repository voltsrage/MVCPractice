using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFoirstApproachExample.Models;

namespace EFDbFoirstApproachExample.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();

            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}
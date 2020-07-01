﻿using EFDbFoirstApproachExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDbFoirstApproachExample.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        public ActionResult Index()
        {
            TrentBasDbContext db = new TrentBasDbContext();

            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}
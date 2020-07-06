using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrentBas.DataLayer;
using TrentBas.DomainModels.Models;

namespace EFDbFoirstApproachExample.ApiControllers
{
    public class CategoriesController : ApiController
    {
        public List<Category> Get()
        {
            TrentBasDbContext db = new TrentBasDbContext();
            List<Category> categories = db.Categories.ToList();
            return categories;
        }

        public Category GetCategoriesByCategoryID(long CategoryID)
        {
            TrentBasDbContext db = new TrentBasDbContext();
            Category existingCategory = db.Categories.Where(b => b.CategoryID == CategoryID).FirstOrDefault();
            return existingCategory;
        }
    }
}

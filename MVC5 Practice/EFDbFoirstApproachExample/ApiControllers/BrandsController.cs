using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrentBas.DomainModels.Models;
using TrentBas.DataLayer;

namespace EFDbFoirstApproachExample.ApiControllers
{
    public class BrandsController : ApiController
    {
        public List<Brand> Get()
        {
            TrentBasDbContext db = new TrentBasDbContext();
            List<Brand> brands = db.Brands.ToList();
            return brands; 
        }

        public Brand GetBrandsByBrandID(long BrandID)
        {
            TrentBasDbContext db = new TrentBasDbContext();
            Brand existingBrand = db.Brands.Where(b=>b.BrandID == BrandID).FirstOrDefault();
            return existingBrand;
        }

        [Authorize(Roles ="Admin")]
        public void PostBrand(Brand newBrand)
        {
            TrentBasDbContext db = new TrentBasDbContext();
            db.Brands.Add(newBrand);
            db.SaveChanges();   
        }


        public void PutBrand(Brand brandData)
        {
            TrentBasDbContext db = new TrentBasDbContext();
            Brand existingBrand = db.Brands.Where(b => b.BrandID == brandData.BrandID).FirstOrDefault();
            existingBrand.BrandName = brandData.BrandName;
            db.SaveChanges();
        }

        public void DeleteBrand(long BrandID)
        {
            TrentBasDbContext db = new TrentBasDbContext();
            Brand existingBrand = db.Brands.Where(b => b.BrandID == BrandID).FirstOrDefault();
            db.Brands.Remove(existingBrand);
            db.SaveChanges();
        }
    }
}

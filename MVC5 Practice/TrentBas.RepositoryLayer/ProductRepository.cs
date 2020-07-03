using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrentBas.DomainModels.Models;
using TrentBas.RepositoryContracts;
using TrentBas.DataLayer;


namespace TrentBas.RepositoryLayer
{
    public class ProductRepository : IProductsRepository
    {
        TrentBasDbContext db = new TrentBasDbContext();

        public void DeleteProduct(long ProductID)
        {
            Product existingProduct = db.Products.Where(temp => temp.ProductID == ProductID).FirstOrDefault();
            db.Products.Remove(existingProduct);
            db.SaveChanges();
        }

        public Product GetProductByProductID(long ProductID)
        {
            Product p = db.Products.Where(t => t.ProductID == ProductID).FirstOrDefault();
            return p;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = db.Products.ToList();
            return products;
        }

        public void InsertProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
        }

        public List<Product> SearchProducts(string ProductName)
        {
            List<Product> products = db.Products.Where(t => t.ProductName.Contains(ProductName)).ToList();
            return products;
        }

        public void UpdateProduct(Product p)
        {
            Product existingProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();

            existingProduct.ProductName = p.ProductName;
            existingProduct.Price = p.Price;
            existingProduct.DateOfPurchase = p.DateOfPurchase;
            existingProduct.CategoryID = p.CategoryID;
            existingProduct.BrandID = p.BrandID;
            existingProduct.AvailabilityStatus = p.AvailabilityStatus;
            existingProduct.Active = p.Active;
            existingProduct.Photo = p.Photo;

            db.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrentBas.DomainModels.Models;
using TrentBas.ServiceContracts;
using TrentBas.DataLayer;
using TrentBas.RepositoryContracts;
using TrentBas.RepositoryLayer;

namespace TrentBas.ServiceLayer
{
    public class ProductService : IService<Product>
    {
        IProductsRepository prodRep;

        public ProductService(IProductsRepository r)
        {
            this.prodRep = r;
        }

        public void Delete(long tID)
        {
            prodRep.DeleteProduct(tID);
        }

        public List<Product> GetT()
        {
            List<Product> products = prodRep.GetProducts();
            return products;
        }

        public Product GetTByTID(long tID)
        {
            Product p = prodRep.GetProductByProductID(tID);
            return p;
        }

        public void InsertT(Product t)
        {
            if(t.Price <= 100000)
            {
                prodRep.InsertProduct(t);
            }
            else
            {
                throw new Exception("Price exceeds the limit!");
            }
        }

        public List<Product> SearchT(string tName)
        {
            List<Product> products = prodRep.SearchProducts(tName);
            return products;
        }

        public void UpdateT(Product t)
        {
            prodRep.UpdateProduct(t);
        }
    }
}

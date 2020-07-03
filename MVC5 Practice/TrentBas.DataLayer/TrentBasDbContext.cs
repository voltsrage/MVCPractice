using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrentBas.DomainModels.Models;


namespace TrentBas.DataLayer
{
    public class TrentBasDbContext:DbContext
    {
        public TrentBasDbContext() : base("CompanyDb")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TrentBasDbContext, Configuration>());
        }


        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}

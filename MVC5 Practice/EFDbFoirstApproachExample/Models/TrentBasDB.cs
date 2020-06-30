using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EFDbFoirstApproachExample.Migrations;

namespace EFDbFoirstApproachExample.Models
{
    public class TrentBasDB : DbContext
    {
        public TrentBasDB() : base("Default")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TrentBasDB,Configuration>());
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
namespace EFDbFoirstApproachExample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDbFoirstApproachExample.Models.TrentBasDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFDbFoirstApproachExample.Models.TrentBasDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Brands.AddOrUpdate(new Models.Brand() { BrandID = 1, BrandName = "Samsung" });
            context.Categories.AddOrUpdate(new Models.Category { CategoryID = 1, CategoryName = "Electronics" });
            context.Products.AddOrUpdate(new Models.Product
            {
                ProductID = 1,
                ProductName = "A50x",
                CategoryID = 1,
                BrandID = 1,
                DateOfPurchase = DateTime.Now.AddMonths(-3),
                Active = true,
                Photo = null,
                Price = 10000,
                AvailabilityStatus = "InStock"
            });
        }
    }
}

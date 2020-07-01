namespace EFDbFoirstApproachExample.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Countr", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Countr");
        }
    }
}

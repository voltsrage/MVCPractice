namespace EFDbFoirstApproachExample.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCountryColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            DropColumn("dbo.AspNetUsers", "Countr");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Countr", c => c.String());
            DropColumn("dbo.AspNetUsers", "Country");
        }
    }
}

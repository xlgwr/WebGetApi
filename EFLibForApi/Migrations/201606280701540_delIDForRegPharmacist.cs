namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delIDForRegPharmacist : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.i_RegPharmacist", "RegPharmacistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.i_RegPharmacist", "RegPharmacistId", c => c.Long(nullable: false));
        }
    }
}

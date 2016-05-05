namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addZhName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.gwd_RegisteredPharmacists_items", "RegNameZH", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.gwd_RegisteredPharmacists_items", "RegNameZH");
        }
    }
}

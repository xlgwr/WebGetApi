namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolCompanyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.gwd_ConstructionCompany_items", "address", c => c.String());
            AddColumn("dbo.gwd_ConstructionCompany_items", "addressZH", c => c.String());
            AddColumn("dbo.gwd_ConstructionCompany_items", "Tel", c => c.String(maxLength: 128));
            AddColumn("dbo.gwd_ConstructionCompany_items", "Fax", c => c.String(maxLength: 128));
            AddColumn("dbo.gwd_ConstructionCompany_items", "Email", c => c.String(maxLength: 128));
            AddColumn("dbo.gwd_ConstructionCompany_items", "webUrl", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.gwd_ConstructionCompany_items", "webUrl");
            DropColumn("dbo.gwd_ConstructionCompany_items", "Email");
            DropColumn("dbo.gwd_ConstructionCompany_items", "Fax");
            DropColumn("dbo.gwd_ConstructionCompany_items", "Tel");
            DropColumn("dbo.gwd_ConstructionCompany_items", "addressZH");
            DropColumn("dbo.gwd_ConstructionCompany_items", "address");
        }
    }
}

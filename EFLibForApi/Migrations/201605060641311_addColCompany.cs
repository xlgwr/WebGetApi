namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.gwd_RegBuildingCompany_items", "Districtarea", c => c.String());
            AddColumn("dbo.gwd_RegBuildingCompany_items", "Emailaddress", c => c.String());
            AddColumn("dbo.gwd_RegBuildingCompany_items", "Faxno", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.gwd_RegBuildingCompany_items", "Faxno");
            DropColumn("dbo.gwd_RegBuildingCompany_items", "Emailaddress");
            DropColumn("dbo.gwd_RegBuildingCompany_items", "Districtarea");
        }
    }
}

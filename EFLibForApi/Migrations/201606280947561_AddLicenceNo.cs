namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLicenceNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.i_SecurityBureau", "LicenceNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.i_SecurityBureau", "LicenceNo");
        }
    }
}

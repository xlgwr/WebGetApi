namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTgetTdisforLegalref : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.gwd_legalref_main", "TGetDis", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.gwd_legalref_main", "TGetDis");
        }
    }
}

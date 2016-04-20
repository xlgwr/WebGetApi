namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2LegalrefColTdis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.gwd_2legalref_main", "TDis", c => c.Long(nullable: false));
            CreateIndex("dbo.gwd_2legalref_main", "TDis", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.gwd_2legalref_main", new[] { "TDis" });
            DropColumn("dbo.gwd_2legalref_main", "TDis");
        }
    }
}

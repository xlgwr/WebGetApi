namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIndexForLegalref : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.gwd_legalref_main", new[] { "TDis" });
            DropIndex("dbo.gwd_legalref_main", new[] { "TGetDis" });
            CreateIndex("dbo.gwd_legalref_main", "TDis");
            CreateIndex("dbo.gwd_legalref_main", "TGetDis");
        }
        
        public override void Down()
        {
            DropIndex("dbo.gwd_legalref_main", new[] { "TGetDis" });
            DropIndex("dbo.gwd_legalref_main", new[] { "TDis" });
            CreateIndex("dbo.gwd_legalref_main", "TGetDis");
            CreateIndex("dbo.gwd_legalref_main", "TDis", unique: true);
        }
    }
}

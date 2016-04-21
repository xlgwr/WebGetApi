namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addKeyForLegalref : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.gwd_legalref_main", new[] { "TDis" });
            DropIndex("dbo.gwd_legalref_main", new[] { "TGetDis" });
            DropPrimaryKey("dbo.gwd_legalref_main");
            AddPrimaryKey("dbo.gwd_legalref_main", new[] { "Tid", "Tdate", "TDis", "TIndex" });
            CreateIndex("dbo.gwd_legalref_main", "TGetDis");
        }
        
        public override void Down()
        {
            DropIndex("dbo.gwd_legalref_main", new[] { "TGetDis" });
            DropPrimaryKey("dbo.gwd_legalref_main");
            AddPrimaryKey("dbo.gwd_legalref_main", new[] { "Tid", "Tdate", "TIndex" });
            CreateIndex("dbo.gwd_legalref_main", "TGetDis");
            CreateIndex("dbo.gwd_legalref_main", "TDis");
        }
    }
}

namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCaseNoForLegalref : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.gwd_legalref_main");
            AddColumn("dbo.gwd_legalref_main", "caseNo", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.gwd_legalref_main", new[] { "Tid", "caseNo", "Tdate", "TDis", "TIndex" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.gwd_legalref_main");
            DropColumn("dbo.gwd_legalref_main", "caseNo");
            AddPrimaryKey("dbo.gwd_legalref_main", new[] { "Tid", "Tdate", "TDis", "TIndex" });
        }
    }
}

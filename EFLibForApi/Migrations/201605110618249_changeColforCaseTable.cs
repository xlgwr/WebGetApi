namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeColforCaseTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.gwd_Case_items", "CourtID", c => c.String());
            AlterColumn("dbo.gwd_Case_items", "Judge", c => c.String());
            AlterColumn("dbo.gwd_Case_items", "CYear", c => c.String());
            AlterColumn("dbo.gwd_Case_items", "CourtDay", c => c.String());
            AlterColumn("dbo.gwd_Case_items", "Hearing", c => c.String());
            AlterColumn("dbo.gwd_Case_items", "CaseNo", c => c.String());
            AlterColumn("dbo.gwd_Case_items", "CaseType", c => c.String());
            AlterColumn("dbo.gwd_Case_items", "PlainTiff", c => c.String());
            AlterColumn("dbo.gwd_Case_items", "Defendant", c => c.String());
            AlterColumn("dbo.gwd_Case_items", "Cause", c => c.String());
            AlterColumn("dbo.gwd_Case_items", "Nature", c => c.String());
            AlterColumn("dbo.gwd_Case_items", "Representation", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.gwd_Case_items", "Representation", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Case_items", "Nature", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Case_items", "Cause", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Case_items", "Defendant", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Case_items", "PlainTiff", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Case_items", "CaseType", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Case_items", "CaseNo", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Case_items", "Hearing", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Case_items", "CourtDay", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Case_items", "CYear", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Case_items", "Judge", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Case_items", "CourtID", c => c.String(unicode: false, storeType: "text"));
        }
    }
}

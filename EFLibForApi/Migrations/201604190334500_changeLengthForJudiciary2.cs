namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeLengthForJudiciary2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.gwd_Judiciary_items", "CourtID", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Judiciary_items", "Judge", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Judiciary_items", "CYear", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Judiciary_items", "CourtDay", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Judiciary_items", "Hearing", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Judiciary_items", "CaseNo", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Judiciary_items", "CaseType", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Judiciary_items", "PlainTiff", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Judiciary_items", "Defendant", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Judiciary_items", "Cause", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Judiciary_items", "Nature", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.gwd_Judiciary_items", "Representation", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.gwd_Judiciary_items", "Representation", c => c.String(maxLength: 800, unicode: false));
            AlterColumn("dbo.gwd_Judiciary_items", "Nature", c => c.String(maxLength: 300, unicode: false));
            AlterColumn("dbo.gwd_Judiciary_items", "Cause", c => c.String(maxLength: 800));
            AlterColumn("dbo.gwd_Judiciary_items", "Defendant", c => c.String(maxLength: 800, unicode: false));
            AlterColumn("dbo.gwd_Judiciary_items", "PlainTiff", c => c.String(maxLength: 800, unicode: false));
            AlterColumn("dbo.gwd_Judiciary_items", "CaseType", c => c.String(maxLength: 300, unicode: false));
            AlterColumn("dbo.gwd_Judiciary_items", "CaseNo", c => c.String(maxLength: 300, unicode: false));
            AlterColumn("dbo.gwd_Judiciary_items", "Hearing", c => c.String(maxLength: 300, unicode: false));
            AlterColumn("dbo.gwd_Judiciary_items", "CourtDay", c => c.String(maxLength: 300, unicode: false));
            AlterColumn("dbo.gwd_Judiciary_items", "CYear", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_Judiciary_items", "Judge", c => c.String(maxLength: 800, unicode: false));
            AlterColumn("dbo.gwd_Judiciary_items", "CourtID", c => c.String(maxLength: 300, unicode: false));
        }
    }
}

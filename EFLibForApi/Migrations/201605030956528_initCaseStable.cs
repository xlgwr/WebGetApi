namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initCaseStable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.gwd_AppealRecord_main", new[] { "TGetDis" });
            DropIndex("dbo.gwd_AppealRecord_main", new[] { "addDate" });
            CreateTable(
                "dbo.gwd_AppealCases",
                c => new
                    {
                        Tid = c.Long(nullable: false, identity: true),
                        tLang = c.Long(nullable: false),
                        tkeyNo = c.String(nullable: false, maxLength: 128),
                        tIndex = c.Long(nullable: false),
                        caseNo = c.String(maxLength: 128),
                        caseDate = c.String(maxLength: 128),
                        TDis = c.Long(nullable: false),
                        TGetDis = c.Long(nullable: false),
                        ReportedIn = c.String(),
                        tname = c.String(maxLength: 200),
                        ttype = c.String(maxLength: 200),
                        Remark = c.String(unicode: false),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .Index(t => t.caseNo)
                .Index(t => t.TDis)
                .Index(t => t.TGetDis)
                .Index(t => t.addDate);
            
            CreateTable(
                "dbo.gwd_RatioDecidendis",
                c => new
                    {
                        Tid = c.Long(nullable: false, identity: true),
                        caseNo = c.String(maxLength: 128),
                        caseDate = c.String(maxLength: 128),
                        tLang = c.Long(nullable: false),
                        tname = c.String(maxLength: 200),
                        ttype = c.String(maxLength: 200),
                        thtml = c.String(unicode: false, storeType: "text"),
                        Remark = c.String(unicode: false),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Tid)
                .Index(t => t.caseNo)
                .Index(t => t.caseDate)
                .Index(t => t.addDate);
            
            DropTable("dbo.gwd_AppealRecord_main");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.gwd_AppealRecord_main",
                c => new
                    {
                        Tid = c.Long(nullable: false, identity: true),
                        caseNo = c.String(nullable: false, maxLength: 128),
                        Tdate = c.String(nullable: false, maxLength: 128),
                        TDis = c.Long(nullable: false),
                        TIndex = c.Int(nullable: false),
                        TGetDis = c.Long(nullable: false),
                        ReportedIn = c.String(),
                        tLang = c.Long(nullable: false),
                        tname = c.String(maxLength: 200),
                        ttype = c.String(maxLength: 200),
                        thtml = c.String(unicode: false, storeType: "text"),
                        Remark = c.String(unicode: false),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tid, t.caseNo, t.Tdate, t.TDis, t.TIndex });
            
            DropIndex("dbo.gwd_RatioDecidendis", new[] { "addDate" });
            DropIndex("dbo.gwd_RatioDecidendis", new[] { "caseDate" });
            DropIndex("dbo.gwd_RatioDecidendis", new[] { "caseNo" });
            DropIndex("dbo.gwd_AppealCases", new[] { "addDate" });
            DropIndex("dbo.gwd_AppealCases", new[] { "TGetDis" });
            DropIndex("dbo.gwd_AppealCases", new[] { "TDis" });
            DropIndex("dbo.gwd_AppealCases", new[] { "caseNo" });
            DropTable("dbo.gwd_RatioDecidendis");
            DropTable("dbo.gwd_AppealCases");
            CreateIndex("dbo.gwd_AppealRecord_main", "addDate");
            CreateIndex("dbo.gwd_AppealRecord_main", "TGetDis");
        }
    }
}

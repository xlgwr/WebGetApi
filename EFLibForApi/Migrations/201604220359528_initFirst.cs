namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class initFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.gwd_ICRIS_items",
                c => new
                    {
                        Tid = c.String(nullable: false, maxLength: 128),
                        tcomp = c.String(maxLength: 200, unicode: false),
                        tclass = c.String(maxLength: 100, unicode: false),
                        tStartDate = c.String(maxLength: 100),
                        tCompStartDate = c.String(maxLength: 100),
                        tCompStart = c.String(maxLength: 200, unicode: false),
                        tNows = c.String(maxLength: 100),
                        tRemarkNow = c.String(maxLength: 200),
                        tModel = c.String(maxLength: 100),
                        tCloseDate = c.String(maxLength: 100),
                        tSaveBook = c.String(maxLength: 50),
                        tImEvens = c.String(maxLength: 100, unicode: false),
                        tSearchRes = c.String(maxLength: 100),
                        Remark = c.String(unicode: false, storeType: "text"),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Tid)
                .ForeignKey("dbo.gwd_ICRIS_main", t => t.Tid)
                .Index(t => t.Tid)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_ICRIS_main",
                c => new
                    {
                        Tid = c.String(nullable: false, maxLength: 128),
                        tname = c.String(maxLength: 50),
                        ttype = c.String(maxLength: 50),
                        tcontent = c.String(maxLength: 100, unicode: false),
                        tGetTable = c.String(unicode: false, storeType: "text"),
                        thtml = c.String(unicode: false, storeType: "text"),
                        Remark = c.String(unicode: false, storeType: "text"),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Tid)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_Judiciary_items",
                c => new
                    {
                        Tid = c.String(nullable: false, maxLength: 128),
                        Tindex = c.Int(nullable: false),
                        SerialNo = c.Int(nullable: false),
                        CourtID = c.String(unicode: false, storeType: "text"),
                        Judge = c.String(unicode: false, storeType: "text"),
                        CYear = c.String(unicode: false, storeType: "text"),
                        CourtDay = c.String(unicode: false, storeType: "text"),
                        Hearing = c.String(unicode: false, storeType: "text"),
                        CaseNo = c.String(unicode: false, storeType: "text"),
                        CaseType = c.String(unicode: false, storeType: "text"),
                        PlainTiff = c.String(unicode: false, storeType: "text"),
                        Defendant = c.String(unicode: false, storeType: "text"),
                        Cause = c.String(unicode: false, storeType: "text"),
                        Nature = c.String(unicode: false, storeType: "text"),
                        Representation = c.String(unicode: false, storeType: "text"),
                        Remark = c.String(unicode: false, storeType: "text"),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tid, t.Tindex })
                .ForeignKey("dbo.gwd_Judiciary_main", t => t.Tid, cascadeDelete: true)
                .Index(t => t.Tid)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_Judiciary_main",
                c => new
                    {
                        Tid = c.String(nullable: false, maxLength: 128),
                        tname = c.String(maxLength: 50),
                        ttype = c.String(maxLength: 50),
                        tcontent = c.String(maxLength: 100, unicode: false),
                        tGetTable = c.String(unicode: false, storeType: "text"),
                        thtml = c.String(unicode: false, storeType: "text"),
                        Remark = c.String(unicode: false, storeType: "text"),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Tid)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_legalref_main",
                c => new
                    {
                        Tid = c.String(nullable: false, maxLength: 128),
                        Tdate = c.String(nullable: false, maxLength: 128),
                        TDis = c.Long(nullable: false),
                        TIndex = c.Int(nullable: false),
                        TGetDis = c.Long(nullable: false),
                        ReportedIn = c.String(),
                        tname = c.String(maxLength: 50),
                        ttype = c.String(maxLength: 50),
                        tcontent = c.String(maxLength: 100, unicode: false),
                        tGetTable = c.String(unicode: false, storeType: "text"),
                        thtml = c.String(unicode: false, storeType: "text"),
                        Remark = c.String(unicode: false, storeType: "text"),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tid, t.Tdate, t.TDis, t.TIndex })
                .Index(t => t.TGetDis)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.m_parameter",
                c => new
                    {
                        paramkey = c.String(nullable: false, maxLength: 16),
                        paramvalue = c.String(maxLength: 50),
                        paramtype = c.String(maxLength: 16),
                        Remark = c.String(unicode: false, storeType: "text"),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.paramkey)
                .Index(t => t.addDate);

        }

        public override void Down()
        {
            DropForeignKey("dbo.gwd_Judiciary_items", "Tid", "dbo.gwd_Judiciary_main");
            DropForeignKey("dbo.gwd_ICRIS_items", "Tid", "dbo.gwd_ICRIS_main");
            DropIndex("dbo.m_parameter", new[] { "addDate" });
            DropIndex("dbo.gwd_legalref_main", new[] { "addDate" });
            DropIndex("dbo.gwd_legalref_main", new[] { "TGetDis" });
            DropIndex("dbo.gwd_Judiciary_main", new[] { "addDate" });
            DropIndex("dbo.gwd_Judiciary_items", new[] { "addDate" });
            DropIndex("dbo.gwd_Judiciary_items", new[] { "Tid" });
            DropIndex("dbo.gwd_ICRIS_main", new[] { "addDate" });
            DropIndex("dbo.gwd_ICRIS_items", new[] { "addDate" });
            DropIndex("dbo.gwd_ICRIS_items", new[] { "Tid" });
            DropTable("dbo.m_parameter");
            DropTable("dbo.gwd_legalref_main");
            DropTable("dbo.gwd_Judiciary_main");
            DropTable("dbo.gwd_Judiciary_items");
            DropTable("dbo.gwd_ICRIS_main");
            DropTable("dbo.gwd_ICRIS_items");
        }
    }
}

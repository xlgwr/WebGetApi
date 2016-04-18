namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class initFrist : DbMigration
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
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Tid)
                .ForeignKey("dbo.gwd_ICRIS_main", t => t.Tid)
                .Index(t => t.Tid);

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
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Tid);

            CreateTable(
                "dbo.gwd_Judiciary_items",
                c => new
                    {
                        Tid = c.String(nullable: false, maxLength: 128),
                        SerialNo = c.Int(nullable: false),
                        CourtID = c.String(maxLength: 100, unicode: false),
                        Judge = c.String(maxLength: 200, unicode: false),
                        CYear = c.String(maxLength: 100),
                        CourtDay = c.String(maxLength: 100, unicode: false),
                        Hearing = c.String(maxLength: 100, unicode: false),
                        CaseNo = c.String(maxLength: 100, unicode: false),
                        CaseType = c.String(maxLength: 100, unicode: false),
                        PlainTiff = c.String(maxLength: 200, unicode: false),
                        Defendant = c.String(maxLength: 200, unicode: false),
                        Cause = c.String(maxLength: 500),
                        Nature = c.String(maxLength: 100, unicode: false),
                        Representation = c.String(maxLength: 100, unicode: false),
                        Remark = c.String(unicode: false, storeType: "text"),
                        tStatus = c.Int(nullable: false),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Tid)
                .ForeignKey("dbo.gwd_Judiciary_main", t => t.Tid)
                .Index(t => t.Tid);

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
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Tid);

            CreateTable(
                "dbo.m_parameter",
                c => new
                    {
                        paramkey = c.String(nullable: false, maxLength: 16),
                        paramvalue = c.String(maxLength: 50),
                        paramtype = c.String(maxLength: 16),
                        Remark = c.String(unicode: false, storeType: "text"),
                        tStatus = c.Int(nullable: false),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.paramkey);

        }

        public override void Down()
        {
            DropForeignKey("dbo.gwd_Judiciary_items", "Tid", "dbo.gwd_Judiciary_main");
            DropForeignKey("dbo.gwd_ICRIS_items", "Tid", "dbo.gwd_ICRIS_main");
            DropIndex("dbo.gwd_Judiciary_items", new[] { "Tid" });
            DropIndex("dbo.gwd_ICRIS_items", new[] { "Tid" });
            DropTable("dbo.m_parameter");
            DropTable("dbo.gwd_Judiciary_main");
            DropTable("dbo.gwd_Judiciary_items");
            DropTable("dbo.gwd_ICRIS_main");
            DropTable("dbo.gwd_ICRIS_items");
        }
    }
}

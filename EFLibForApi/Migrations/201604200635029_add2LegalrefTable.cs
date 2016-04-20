namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2LegalrefTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.gwd_2legalref_items",
                c => new
                    {
                        Tid = c.String(nullable: false, maxLength: 128),
                        Tdate = c.String(nullable: false, maxLength: 128),
                        TIndex = c.Int(nullable: false),
                        tlang = c.String(),
                        isPressSummary = c.Int(nullable: false),
                        thtml = c.String(unicode: false, storeType: "text"),
                        Remark = c.String(unicode: false, storeType: "text"),
                        tStatus = c.Int(nullable: false),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tid, t.Tdate, t.TIndex })
                .ForeignKey("dbo.gwd_2legalref_main", t => new { t.Tid, t.Tdate }, cascadeDelete: true)
                .Index(t => new { t.Tid, t.Tdate })
                .Index(t => t.addDate);
            
            CreateTable(
                "dbo.gwd_2legalref_main",
                c => new
                    {
                        Tid = c.String(nullable: false, maxLength: 128),
                        Tdate = c.String(nullable: false, maxLength: 128),
                        ReportedIn = c.String(),
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
                .PrimaryKey(t => new { t.Tid, t.Tdate })
                .Index(t => t.addDate);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.gwd_2legalref_items", new[] { "Tid", "Tdate" }, "dbo.gwd_2legalref_main");
            DropIndex("dbo.gwd_2legalref_main", new[] { "addDate" });
            DropIndex("dbo.gwd_2legalref_items", new[] { "addDate" });
            DropIndex("dbo.gwd_2legalref_items", new[] { "Tid", "Tdate" });
            DropTable("dbo.gwd_2legalref_main");
            DropTable("dbo.gwd_2legalref_items");
        }
    }
}

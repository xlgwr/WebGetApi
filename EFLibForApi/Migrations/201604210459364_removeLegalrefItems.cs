namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeLegalrefItems : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.gwd_legalref_items", new[] { "Tid", "Tdate" }, "dbo.gwd_legalref_main");
            DropIndex("dbo.gwd_legalref_items", new[] { "Tid", "Tdate" });
            DropIndex("dbo.gwd_legalref_items", new[] { "addDate" });
            DropPrimaryKey("dbo.gwd_legalref_main");
            AddColumn("dbo.gwd_legalref_main", "TIndex", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.gwd_legalref_main", new[] { "Tid", "Tdate", "TIndex" });
            DropTable("dbo.gwd_legalref_items");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.gwd_legalref_items",
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
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tid, t.Tdate, t.TIndex });
            
            DropPrimaryKey("dbo.gwd_legalref_main");
            DropColumn("dbo.gwd_legalref_main", "TIndex");
            AddPrimaryKey("dbo.gwd_legalref_main", new[] { "Tid", "Tdate" });
            CreateIndex("dbo.gwd_legalref_items", "addDate");
            CreateIndex("dbo.gwd_legalref_items", new[] { "Tid", "Tdate" });
            AddForeignKey("dbo.gwd_legalref_items", new[] { "Tid", "Tdate" }, "dbo.gwd_legalref_main", new[] { "Tid", "Tdate" }, cascadeDelete: true);
        }
    }
}

namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addSecurityBureauTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.gwd_SecurityBureau_items",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    LicenceNo = c.String(maxLength: 128),
                    CompanyName = c.String(maxLength: 128),
                    ChineseName = c.String(maxLength: 128),
                    WorkType = c.String(),
                    address = c.String(),
                    TelNo = c.String(maxLength: 128),
                    tname = c.String(maxLength: 500),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.LicenceNo)
                .Index(t => t.CompanyName)
                .Index(t => t.addDate);

        }

        public override void Down()
        {
            DropForeignKey("dbo.gwd_SecurityBureau_items", "htmlID", "dbo.entityCommMain");
            DropIndex("dbo.gwd_SecurityBureau_items", new[] { "addDate" });
            DropIndex("dbo.gwd_SecurityBureau_items", new[] { "CompanyName" });
            DropIndex("dbo.gwd_SecurityBureau_items", new[] { "LicenceNo" });
            DropIndex("dbo.gwd_SecurityBureau_items", new[] { "htmlID" });
            DropTable("dbo.gwd_SecurityBureau_items");
        }
    }
}

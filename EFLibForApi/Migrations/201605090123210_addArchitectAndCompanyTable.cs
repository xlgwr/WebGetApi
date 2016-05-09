namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addArchitectAndCompanyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.gwd_architect_items",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    RegNo = c.String(maxLength: 128),
                    MembershipNo = c.String(maxLength: 128),
                    MembershipNoZH = c.String(maxLength: 128),
                    MembershipType = c.String(),
                    MembershipYear = c.String(maxLength: 128),
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
                .Index(t => t.RegNo)
                .Index(t => t.MembershipNo)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_ConstructionCompany_items",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    ConstructionCyID = c.String(maxLength: 128),
                    CompanyName = c.String(maxLength: 128),
                    ChineseName = c.String(maxLength: 128),
                    Summary = c.String(),
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
                .Index(t => t.ConstructionCyID)
                .Index(t => t.CompanyName)
                .Index(t => t.addDate);

        }

        public override void Down()
        {
            DropForeignKey("dbo.gwd_ConstructionCompany_items", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.gwd_architect_items", "htmlID", "dbo.entityCommMain");
            DropIndex("dbo.gwd_ConstructionCompany_items", new[] { "addDate" });
            DropIndex("dbo.gwd_ConstructionCompany_items", new[] { "CompanyName" });
            DropIndex("dbo.gwd_ConstructionCompany_items", new[] { "ConstructionCyID" });
            DropIndex("dbo.gwd_ConstructionCompany_items", new[] { "htmlID" });
            DropIndex("dbo.gwd_architect_items", new[] { "addDate" });
            DropIndex("dbo.gwd_architect_items", new[] { "MembershipNo" });
            DropIndex("dbo.gwd_architect_items", new[] { "RegNo" });
            DropIndex("dbo.gwd_architect_items", new[] { "htmlID" });
            DropTable("dbo.gwd_ConstructionCompany_items");
            DropTable("dbo.gwd_architect_items");
        }
    }
}

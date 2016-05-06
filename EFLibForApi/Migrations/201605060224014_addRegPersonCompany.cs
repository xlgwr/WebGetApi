namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addRegPersonCompany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.gwd_RegArchitect_items",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    RegNo = c.String(maxLength: 128),
                    ArchitectsName = c.String(maxLength: 128),
                    ArchitectsNameZH = c.String(maxLength: 128),
                    BuildingSafety = c.String(),
                    ExpiryDate = c.String(maxLength: 128),
                    PhoneNo = c.String(maxLength: 128),
                    tname = c.String(maxLength: 200),
                    ttype = c.String(maxLength: 200),
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
                .Index(t => t.ArchitectsName)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_RegBuildingCompany_items",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    RegNo = c.String(maxLength: 128),
                    CompanyName = c.String(maxLength: 128),
                    CompanyNameZH = c.String(maxLength: 128),
                    AuthorizedSignatory = c.String(maxLength: 128),
                    classType = c.String(),
                    BuildingSafety = c.String(),
                    ExpiryDate = c.String(maxLength: 128),
                    PhoneNo = c.String(maxLength: 128),
                    tname = c.String(maxLength: 200),
                    ttype = c.String(maxLength: 200),
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
                .Index(t => t.CompanyName)
                .Index(t => t.addDate);

        }

        public override void Down()
        {
            DropForeignKey("dbo.gwd_RegBuildingCompany_items", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.gwd_RegArchitect_items", "htmlID", "dbo.entityCommMain");
            DropIndex("dbo.gwd_RegBuildingCompany_items", new[] { "addDate" });
            DropIndex("dbo.gwd_RegBuildingCompany_items", new[] { "CompanyName" });
            DropIndex("dbo.gwd_RegBuildingCompany_items", new[] { "RegNo" });
            DropIndex("dbo.gwd_RegBuildingCompany_items", new[] { "htmlID" });
            DropIndex("dbo.gwd_RegArchitect_items", new[] { "addDate" });
            DropIndex("dbo.gwd_RegArchitect_items", new[] { "ArchitectsName" });
            DropIndex("dbo.gwd_RegArchitect_items", new[] { "RegNo" });
            DropIndex("dbo.gwd_RegArchitect_items", new[] { "htmlID" });
            DropTable("dbo.gwd_RegBuildingCompany_items");
            DropTable("dbo.gwd_RegArchitect_items");
        }
    }
}

namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addSecretariesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.gwd_Secretaries_items",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    Name = c.String(maxLength: 128),
                    Grade = c.String(maxLength: 128),
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
                .Index(t => t.Name)
                .Index(t => t.addDate);

        }

        public override void Down()
        {
            DropForeignKey("dbo.gwd_Secretaries_items", "htmlID", "dbo.entityCommMain");
            DropIndex("dbo.gwd_Secretaries_items", new[] { "addDate" });
            DropIndex("dbo.gwd_Secretaries_items", new[] { "Name" });
            DropIndex("dbo.gwd_Secretaries_items", new[] { "htmlID" });
            DropTable("dbo.gwd_Secretaries_items");
        }
    }
}

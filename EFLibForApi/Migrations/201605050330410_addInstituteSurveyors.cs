namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addInstituteSurveyors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.gwd_InstituteSurveyors_items",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    CompanyName = c.String(maxLength: 128),
                    Address = c.String(),
                    ContactPerson = c.String(),
                    TelNo = c.String(),
                    Fax = c.String(),
                    Email = c.String(),
                    Website = c.String(),
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
                .Index(t => t.CompanyName)
                .Index(t => t.addDate);

        }

        public override void Down()
        {
            DropForeignKey("dbo.gwd_InstituteSurveyors_items", "htmlID", "dbo.entityCommMain");
            DropIndex("dbo.gwd_InstituteSurveyors_items", new[] { "addDate" });
            DropIndex("dbo.gwd_InstituteSurveyors_items", new[] { "CompanyName" });
            DropIndex("dbo.gwd_InstituteSurveyors_items", new[] { "htmlID" });
            DropTable("dbo.gwd_InstituteSurveyors_items");
        }
    }
}

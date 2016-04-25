namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHKlawsocTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.gwd_hklawsoc_main",
                c => new
                    {
                        Tid = c.String(nullable: false, maxLength: 128),
                        TIndex = c.Int(nullable: false),
                        LawyerName = c.String(),
                        ChineseName = c.String(),
                        BeforeName = c.String(),
                        ApproveDate = c.String(),
                        ApproveCountry = c.String(),
                        OtherDate = c.String(),
                        LawyerEmail = c.String(),
                        Title = c.String(),
                        LawyerCompany = c.String(),
                        ChineseCompany = c.String(),
                        CompanyAddress = c.String(),
                        ChineseAddress = c.String(),
                        Companytel = c.String(),
                        CompanyFax = c.String(),
                        Dxnumber = c.String(),
                        CompanyEmail = c.String(),
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
                .PrimaryKey(t => new { t.Tid, t.TIndex })
                .Index(t => t.addDate);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.gwd_hklawsoc_main", new[] { "addDate" });
            DropTable("dbo.gwd_hklawsoc_main");
        }
    }
}

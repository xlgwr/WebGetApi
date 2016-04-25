namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgwd_ICRIS_DisOrders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.gwd_ICRIS_DisOrders",
                c => new
                    {
                        RecordID = c.String(nullable: false, maxLength: 128),
                        ItemNo = c.String(),
                        CampanyNo = c.String(),
                        CorporateName = c.String(),
                        ChineseName = c.String(),
                        IDCard = c.String(),
                        OverseasPassportID = c.String(),
                        PassportCountry = c.String(),
                        SameNo = c.String(),
                        Remark = c.String(unicode: false, storeType: "text"),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordID)
                .Index(t => t.addDate);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.gwd_ICRIS_DisOrders", new[] { "addDate" });
            DropTable("dbo.gwd_ICRIS_DisOrders");
        }
    }
}

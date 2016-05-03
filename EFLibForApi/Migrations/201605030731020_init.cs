namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.entityCommMain",
                c => new
                    {
                        Tid = c.Long(nullable: false, identity: true),
                        tLang = c.Long(nullable: false),
                        tname = c.String(maxLength: 200),
                        ttype = c.String(maxLength: 200),
                        thtml = c.String(unicode: false, storeType: "text"),
                        Remark = c.String(unicode: false),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Tid)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_Barristers_items",
                c => new
                    {
                        Tid = c.Long(nullable: false, identity: true),
                        tLang = c.Long(nullable: false),
                        tkeyNo = c.String(nullable: false, maxLength: 128),
                        tIndex = c.Long(nullable: false),
                        htmlID = c.Long(nullable: false),
                        LawyerName = c.String(),
                        ChineseName = c.String(),
                        Sex = c.String(),
                        Title = c.String(),
                        Address = c.String(),
                        Telphone = c.String(),
                        Mobile = c.String(),
                        Fax = c.String(),
                        PracticeAreas = c.String(),
                        Email = c.String(),
                        Quals = c.String(),
                        ApproveYear = c.String(),
                        IsMandarin = c.String(),
                        tname = c.String(maxLength: 200),
                        ttype = c.String(maxLength: 200),
                        Remark = c.String(unicode: false),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_GovernmentPhonebook_items",
                c => new
                    {
                        Tid = c.Long(nullable: false, identity: true),
                        tLang = c.Long(nullable: false),
                        tkeyNo = c.String(nullable: false, maxLength: 128),
                        tIndex = c.Long(nullable: false),
                        htmlID = c.Long(nullable: false),
                        FullName = c.String(),
                        Title = c.String(),
                        Address = c.String(),
                        Fax = c.String(),
                        OfficePhone = c.String(),
                        Email = c.String(),
                        tname = c.String(maxLength: 200),
                        ttype = c.String(maxLength: 200),
                        Remark = c.String(unicode: false),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_Lawyers_items",
                c => new
                    {
                        Tid = c.Long(nullable: false, identity: true),
                        tLang = c.Long(nullable: false),
                        tkeyNo = c.String(nullable: false, maxLength: 128),
                        tIndex = c.Long(nullable: false),
                        htmlID = c.Long(nullable: false),
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
                        tname = c.String(maxLength: 200),
                        ttype = c.String(maxLength: 200),
                        Remark = c.String(unicode: false),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_AppealRecord_main",
                c => new
                    {
                        Tid = c.Long(nullable: false, identity: true),
                        caseNo = c.String(nullable: false, maxLength: 128),
                        Tdate = c.String(nullable: false, maxLength: 128),
                        TDis = c.Long(nullable: false),
                        TIndex = c.Int(nullable: false),
                        TGetDis = c.Long(nullable: false),
                        ReportedIn = c.String(),
                        tLang = c.Long(nullable: false),
                        tname = c.String(maxLength: 200),
                        ttype = c.String(maxLength: 200),
                        thtml = c.String(unicode: false, storeType: "text"),
                        Remark = c.String(unicode: false),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tid, t.caseNo, t.Tdate, t.TDis, t.TIndex })
                .Index(t => t.TGetDis)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_Case_items",
                c => new
                    {
                        Tid = c.Long(nullable: false, identity: true),
                        tLang = c.Long(nullable: false),
                        tkeyNo = c.String(nullable: false, maxLength: 128),
                        tIndex = c.Long(nullable: false),
                        htmlID = c.Long(nullable: false),
                        SerialNo = c.Int(nullable: false),
                        CourtID = c.String(unicode: false, storeType: "text"),
                        Judge = c.String(unicode: false, storeType: "text"),
                        CYear = c.String(unicode: false, storeType: "text"),
                        CourtDay = c.String(unicode: false, storeType: "text"),
                        Hearing = c.String(unicode: false, storeType: "text"),
                        CaseNo = c.String(unicode: false, storeType: "text"),
                        CaseType = c.String(unicode: false, storeType: "text"),
                        PlainTiff = c.String(unicode: false, storeType: "text"),
                        Defendant = c.String(unicode: false, storeType: "text"),
                        Cause = c.String(unicode: false, storeType: "text"),
                        Nature = c.String(unicode: false, storeType: "text"),
                        Representation = c.String(unicode: false, storeType: "text"),
                        tname = c.String(maxLength: 200),
                        ttype = c.String(maxLength: 200),
                        Remark = c.String(unicode: false),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.gwd_Case_main", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_Case_main",
                c => new
                    {
                        Tid = c.Long(nullable: false, identity: true),
                        tLang = c.Long(nullable: false),
                        tname = c.String(maxLength: 200),
                        ttype = c.String(maxLength: 200),
                        thtml = c.String(unicode: false, storeType: "text"),
                        Remark = c.String(unicode: false),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Tid)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_CompaniesRegistry_DisOrders",
                c => new
                    {
                        RecordID = c.String(nullable: false, maxLength: 128),
                        ItemNo = c.Long(nullable: false),
                        CampanyNo = c.String(),
                        CorporateName = c.String(),
                        ChineseName = c.String(),
                        IDCard = c.String(),
                        OverseasPassportID = c.String(),
                        PassportCountry = c.String(),
                        SameNo = c.String(),
                        thtml = c.String(unicode: false, storeType: "text"),
                        Remark = c.String(unicode: false),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordID)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_CompaniesRegistry_items",
                c => new
                    {
                        Tid = c.Long(nullable: false, identity: true),
                        tLang = c.Long(nullable: false),
                        tkeyNo = c.String(nullable: false, maxLength: 128),
                        tIndex = c.Long(nullable: false),
                        htmlID = c.Long(nullable: false),
                        CompanyName = c.String(),
                        CompanyNameZH = c.String(),
                        CompanyType = c.String(),
                        FoundDate = c.String(),
                        CurrentState = c.String(),
                        tRemarkNow = c.String(),
                        LiquidationMode = c.String(),
                        DisbandDate = c.String(),
                        ChargeState = c.String(),
                        Important = c.String(),
                        tSearchRes = c.String(),
                        tname = c.String(maxLength: 200),
                        ttype = c.String(maxLength: 200),
                        Remark = c.String(unicode: false),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.gwd_CompaniesRegistry_main", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_CompaniesRegistry_main",
                c => new
                    {
                        Tid = c.Long(nullable: false, identity: true),
                        tLang = c.Long(nullable: false),
                        tname = c.String(maxLength: 200),
                        ttype = c.String(maxLength: 200),
                        thtml = c.String(unicode: false, storeType: "text"),
                        Remark = c.String(unicode: false),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Tid)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.gwd_CompaniesRegistry_itemsChange",
                c => new
                    {
                        Tid = c.Long(nullable: false, identity: true),
                        tLang = c.Long(nullable: false),
                        tkeyNo = c.String(nullable: false, maxLength: 128),
                        tIndex = c.Long(nullable: false),
                        htmlID = c.Long(nullable: false),
                        CompanyName = c.String(),
                        CompanyNameZH = c.String(),
                        EffectiveDate = c.String(),
                        tname = c.String(maxLength: 200),
                        ttype = c.String(maxLength: 200),
                        Remark = c.String(unicode: false),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.gwd_CompaniesRegistry_main", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.addDate);

            CreateTable(
                "dbo.m_parameter",
                c => new
                    {
                        paramkey = c.String(nullable: false, maxLength: 128),
                        paramvalue = c.String(maxLength: 128),
                        paramtype = c.String(maxLength: 128),
                        Remark = c.String(),
                        tStatus = c.Int(nullable: false),
                        ClientIP = c.String(),
                        addDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.paramkey)
                .Index(t => t.addDate);

        }

        public override void Down()
        {
            DropForeignKey("dbo.gwd_CompaniesRegistry_items", "htmlID", "dbo.gwd_CompaniesRegistry_main");
            DropForeignKey("dbo.gwd_CompaniesRegistry_itemsChange", "htmlID", "dbo.gwd_CompaniesRegistry_main");
            DropForeignKey("dbo.gwd_Case_items", "htmlID", "dbo.gwd_Case_main");
            DropForeignKey("dbo.gwd_Lawyers_items", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.gwd_GovernmentPhonebook_items", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.gwd_Barristers_items", "htmlID", "dbo.entityCommMain");
            DropIndex("dbo.m_parameter", new[] { "addDate" });
            DropIndex("dbo.gwd_CompaniesRegistry_itemsChange", new[] { "addDate" });
            DropIndex("dbo.gwd_CompaniesRegistry_itemsChange", new[] { "htmlID" });
            DropIndex("dbo.gwd_CompaniesRegistry_main", new[] { "addDate" });
            DropIndex("dbo.gwd_CompaniesRegistry_items", new[] { "addDate" });
            DropIndex("dbo.gwd_CompaniesRegistry_items", new[] { "htmlID" });
            DropIndex("dbo.gwd_CompaniesRegistry_DisOrders", new[] { "addDate" });
            DropIndex("dbo.gwd_Case_main", new[] { "addDate" });
            DropIndex("dbo.gwd_Case_items", new[] { "addDate" });
            DropIndex("dbo.gwd_Case_items", new[] { "htmlID" });
            DropIndex("dbo.gwd_AppealRecord_main", new[] { "addDate" });
            DropIndex("dbo.gwd_AppealRecord_main", new[] { "TGetDis" });
            DropIndex("dbo.gwd_Lawyers_items", new[] { "addDate" });
            DropIndex("dbo.gwd_Lawyers_items", new[] { "htmlID" });
            DropIndex("dbo.gwd_GovernmentPhonebook_items", new[] { "addDate" });
            DropIndex("dbo.gwd_GovernmentPhonebook_items", new[] { "htmlID" });
            DropIndex("dbo.gwd_Barristers_items", new[] { "addDate" });
            DropIndex("dbo.gwd_Barristers_items", new[] { "htmlID" });
            DropIndex("dbo.entityCommMain", new[] { "addDate" });
            DropTable("dbo.m_parameter");
            DropTable("dbo.gwd_CompaniesRegistry_itemsChange");
            DropTable("dbo.gwd_CompaniesRegistry_main");
            DropTable("dbo.gwd_CompaniesRegistry_items");
            DropTable("dbo.gwd_CompaniesRegistry_DisOrders");
            DropTable("dbo.gwd_Case_main");
            DropTable("dbo.gwd_Case_items");
            DropTable("dbo.gwd_AppealRecord_main");
            DropTable("dbo.gwd_Lawyers_items");
            DropTable("dbo.gwd_GovernmentPhonebook_items");
            DropTable("dbo.gwd_Barristers_items");
            DropTable("dbo.entityCommMain");
        }
    }
}

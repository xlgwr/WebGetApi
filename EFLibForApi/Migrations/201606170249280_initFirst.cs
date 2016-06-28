namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class initFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.entityCommMain",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tname = c.String(maxLength: 500),
                    ttype = c.String(maxLength: 300),
                    thtml = c.String(unicode: false, storeType: "text"),
                    Remark = c.String(unicode: false),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Tid)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.i_Architect",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    ArchitectId = c.String(maxLength: 128),
                    MembershipEn = c.String(maxLength: 128),
                    MembershipCn = c.String(maxLength: 128),
                    MembershipType = c.String(),
                    MembershipYear = c.String(maxLength: 128),
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.ArchitectId)
                .Index(t => t.MembershipEn)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.i_Barristers",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    LawyerId = c.Long(nullable: false),
                    LawyerNameEn = c.String(),
                    LawyerNameCn = c.String(),
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
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(unicode: false),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.i_BuildingCom",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    BuildingComID = c.String(maxLength: 128),
                    CompanyNameEn = c.String(maxLength: 128),
                    CompanyNameCn = c.String(maxLength: 128),
                    Summary = c.String(),
                    AddressEn = c.String(),
                    AddressCn = c.String(),
                    Tel = c.String(maxLength: 128),
                    Fax = c.String(maxLength: 128),
                    Email = c.String(maxLength: 128),
                    WebSite = c.String(maxLength: 128),
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.BuildingComID)
                .Index(t => t.CompanyNameEn)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.i_GovPhonebook",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    GovId = c.Long(nullable: false),
                    GovName = c.String(),
                    FullName = c.String(),
                    PostTitle = c.String(),
                    Address = c.String(),
                    Fax = c.String(),
                    OfficePhone = c.String(),
                    Email = c.String(),
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(unicode: false),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.i_InstituteSurveyors",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    InstituteId = c.Long(nullable: false),
                    CompanyName = c.String(maxLength: 128),
                    Address = c.String(),
                    ContactPerson = c.String(),
                    Tel = c.String(),
                    Fax = c.String(),
                    Email = c.String(),
                    Website = c.String(),
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.CompanyName)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.i_PsychologicalSociety",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    PsychologicalId = c.Long(nullable: false),
                    Name_En = c.String(maxLength: 128),
                    Name_Cn = c.String(maxLength: 128),
                    Address = c.String(),
                    RegisteredNo = c.String(),
                    Specialization = c.String(),
                    Tel = c.String(),
                    Fax = c.String(),
                    Email = c.String(),
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.Name_En)
                .Index(t => t.Name_Cn)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.i_RegArchitect",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    RegArchitectId = c.String(maxLength: 128),
                    ArchitectsName = c.String(maxLength: 128),
                    Type = c.String(maxLength: 128),
                    BuildingSafety = c.String(),
                    ExpiryDate = c.String(maxLength: 128),
                    Tel = c.String(maxLength: 128),
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.RegArchitectId)
                .Index(t => t.ArchitectsName)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.i_RegBuildingCom",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    RegBuildingComId = c.String(maxLength: 128),
                    CompanyName = c.String(maxLength: 128),
                    Type = c.String(maxLength: 128),
                    AuthorizedSignatory = c.String(maxLength: 128),
                    classType = c.String(),
                    BuildingSafety = c.String(),
                    ExpiryDate = c.String(maxLength: 128),
                    Tel = c.String(maxLength: 128),
                    Districtarea = c.String(),
                    Emailaddress = c.String(),
                    Faxno = c.String(),
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.RegBuildingComId)
                .Index(t => t.CompanyName)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.i_RegPharmacist",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    RegPharmacistId = c.Long(nullable: false),
                    RegNo = c.String(maxLength: 128),
                    RegNameEn = c.String(maxLength: 128),
                    RegNameCn = c.String(maxLength: 128),
                    Qualifications = c.String(),
                    RegDate = c.String(maxLength: 128),
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.RegNo)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.i_Secretaries",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    Name = c.String(maxLength: 128),
                    Grade = c.String(maxLength: 128),
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.Name)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.i_SecurityBureau",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    SecurityComId = c.String(maxLength: 128),
                    CompanyNameEn = c.String(maxLength: 128),
                    CompanyNameCn = c.String(maxLength: 128),
                    WorkType = c.String(),
                    address = c.String(),
                    Tel = c.String(maxLength: 128),
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.SecurityComId)
                .Index(t => t.CompanyNameEn)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.i_WithCertLawyers",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    LawyerId = c.Long(nullable: false),
                    LawyerNameEn = c.String(),
                    LawyerNameCn = c.String(),
                    BeforeName = c.String(),
                    ApproveDate = c.String(),
                    ApproveCountry = c.String(),
                    OtherDate = c.String(),
                    LawyerEmail = c.String(),
                    Title = c.String(),
                    LawyerCompanyEn = c.String(),
                    LawyerCompanyCn = c.String(),
                    ComAddressEn = c.String(),
                    ComAddressCn = c.String(),
                    ComTel = c.String(),
                    ComFax = c.String(),
                    DxNO = c.String(),
                    ComEmail = c.String(),
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(unicode: false),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.i_ForeignLawyers",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    LawyerId = c.Long(nullable: false),
                    LawyerNameEn = c.String(),
                    LawyerNameCn = c.String(),
                    BeforeName = c.String(),
                    Jurisdiction = c.String(),
                    Title = c.String(),
                    LawyerCompanyEn = c.String(),
                    LawyerCompanyCn = c.String(),
                    ComAddressEn = c.String(),
                    ComAddressCn = c.String(),
                    ComTel = c.String(),
                    ComFax = c.String(),
                    DxNO = c.String(),
                    ComEmail = c.String(),
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.entityCommMain", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.m_AppealCases",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    caseNo = c.String(maxLength: 128),
                    caseDate = c.String(maxLength: 128),
                    TDis = c.Long(nullable: false),
                    TGetDis = c.Long(nullable: false),
                    ReportedIn = c.String(),
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(unicode: false),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .Index(t => t.caseNo)
                .Index(t => t.TDis)
                .Index(t => t.TGetDis)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.m_Case_items",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tkeyNo = c.String(nullable: false, maxLength: 128),
                    tIndex = c.Long(nullable: false),
                    htmlID = c.Long(nullable: false),
                    SerialNo = c.Int(nullable: false),
                    CourtID = c.String(),
                    Judge = c.String(),
                    CYear = c.String(),
                    CourtDay = c.String(),
                    Hearing = c.String(),
                    CaseNo = c.String(),
                    CaseType = c.String(),
                    Parties = c.String(),
                    PlainTiff = c.String(),
                    Defendant = c.String(),
                    Cause = c.String(),
                    Nature = c.String(),
                    Representation = c.String(),
                    Actiondate = c.String(),
                    Currency = c.String(),
                    Amount = c.String(),
                    CheckField = c.String(),
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(unicode: false),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.m_Case_main", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.m_Case_main",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tname = c.String(maxLength: 500),
                    ttype = c.String(maxLength: 300),
                    thtml = c.String(unicode: false, storeType: "text"),
                    Remark = c.String(unicode: false),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Tid)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.m_CompaniesRegistry_DisOrders",
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
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.RecordID)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.m_CompaniesRegistry_items",
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
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(unicode: false),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.m_CompaniesRegistry_main", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.m_CompaniesRegistry_main",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    tLang = c.Long(nullable: false),
                    tname = c.String(maxLength: 500),
                    ttype = c.String(maxLength: 300),
                    thtml = c.String(unicode: false, storeType: "text"),
                    Remark = c.String(unicode: false),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Tid)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.m_CompaniesRegistry_itemsChange",
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
                    tname = c.String(),
                    ttype = c.String(maxLength: 300),
                    Remark = c.String(unicode: false),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.Tid, t.tLang, t.tkeyNo, t.tIndex })
                .ForeignKey("dbo.m_CompaniesRegistry_main", t => t.htmlID, cascadeDelete: true)
                .Index(t => t.htmlID)
                .Index(t => t.addtime);

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
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.paramkey)
                .Index(t => t.addtime);

            CreateTable(
                "dbo.m_RatioDecidendis",
                c => new
                {
                    Tid = c.Long(nullable: false, identity: true),
                    caseNo = c.String(maxLength: 128),
                    caseDate = c.String(maxLength: 128),
                    TDis = c.Long(nullable: false),
                    TGetDis = c.Long(nullable: false),
                    tLang = c.Long(nullable: false),
                    tname = c.String(maxLength: 500),
                    ttype = c.String(maxLength: 300),
                    thtml = c.String(unicode: false, storeType: "text"),
                    Remark = c.String(unicode: false),
                    tStatus = c.Int(nullable: false),
                    ClientIP = c.String(),
                    adduser = c.String(maxLength: 128),
                    upduser = c.String(maxLength: 128),
                    addtime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    updtime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Tid)
                .Index(t => t.caseNo)
                .Index(t => t.caseDate)
                .Index(t => t.TDis)
                .Index(t => t.TGetDis)
                .Index(t => t.addtime);

        }

        public override void Down()
        {
            DropForeignKey("dbo.m_CompaniesRegistry_items", "htmlID", "dbo.m_CompaniesRegistry_main");
            DropForeignKey("dbo.m_CompaniesRegistry_itemsChange", "htmlID", "dbo.m_CompaniesRegistry_main");
            DropForeignKey("dbo.m_Case_items", "htmlID", "dbo.m_Case_main");
            DropForeignKey("dbo.i_ForeignLawyers", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.i_WithCertLawyers", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.i_SecurityBureau", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.i_Secretaries", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.i_RegPharmacist", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.i_RegBuildingCom", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.i_RegArchitect", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.i_PsychologicalSociety", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.i_InstituteSurveyors", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.i_GovPhonebook", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.i_BuildingCom", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.i_Barristers", "htmlID", "dbo.entityCommMain");
            DropForeignKey("dbo.i_Architect", "htmlID", "dbo.entityCommMain");
            DropIndex("dbo.m_RatioDecidendis", new[] { "addtime" });
            DropIndex("dbo.m_RatioDecidendis", new[] { "TGetDis" });
            DropIndex("dbo.m_RatioDecidendis", new[] { "TDis" });
            DropIndex("dbo.m_RatioDecidendis", new[] { "caseDate" });
            DropIndex("dbo.m_RatioDecidendis", new[] { "caseNo" });
            DropIndex("dbo.m_parameter", new[] { "addtime" });
            DropIndex("dbo.m_CompaniesRegistry_itemsChange", new[] { "addtime" });
            DropIndex("dbo.m_CompaniesRegistry_itemsChange", new[] { "htmlID" });
            DropIndex("dbo.m_CompaniesRegistry_main", new[] { "addtime" });
            DropIndex("dbo.m_CompaniesRegistry_items", new[] { "addtime" });
            DropIndex("dbo.m_CompaniesRegistry_items", new[] { "htmlID" });
            DropIndex("dbo.m_CompaniesRegistry_DisOrders", new[] { "addtime" });
            DropIndex("dbo.m_Case_main", new[] { "addtime" });
            DropIndex("dbo.m_Case_items", new[] { "addtime" });
            DropIndex("dbo.m_Case_items", new[] { "htmlID" });
            DropIndex("dbo.m_AppealCases", new[] { "addtime" });
            DropIndex("dbo.m_AppealCases", new[] { "TGetDis" });
            DropIndex("dbo.m_AppealCases", new[] { "TDis" });
            DropIndex("dbo.m_AppealCases", new[] { "caseNo" });
            DropIndex("dbo.i_ForeignLawyers", new[] { "addtime" });
            DropIndex("dbo.i_ForeignLawyers", new[] { "htmlID" });
            DropIndex("dbo.i_WithCertLawyers", new[] { "addtime" });
            DropIndex("dbo.i_WithCertLawyers", new[] { "htmlID" });
            DropIndex("dbo.i_SecurityBureau", new[] { "addtime" });
            DropIndex("dbo.i_SecurityBureau", new[] { "CompanyNameEn" });
            DropIndex("dbo.i_SecurityBureau", new[] { "SecurityComId" });
            DropIndex("dbo.i_SecurityBureau", new[] { "htmlID" });
            DropIndex("dbo.i_Secretaries", new[] { "addtime" });
            DropIndex("dbo.i_Secretaries", new[] { "Name" });
            DropIndex("dbo.i_Secretaries", new[] { "htmlID" });
            DropIndex("dbo.i_RegPharmacist", new[] { "addtime" });
            DropIndex("dbo.i_RegPharmacist", new[] { "RegNo" });
            DropIndex("dbo.i_RegPharmacist", new[] { "htmlID" });
            DropIndex("dbo.i_RegBuildingCom", new[] { "addtime" });
            DropIndex("dbo.i_RegBuildingCom", new[] { "CompanyName" });
            DropIndex("dbo.i_RegBuildingCom", new[] { "RegBuildingComId" });
            DropIndex("dbo.i_RegBuildingCom", new[] { "htmlID" });
            DropIndex("dbo.i_RegArchitect", new[] { "addtime" });
            DropIndex("dbo.i_RegArchitect", new[] { "ArchitectsName" });
            DropIndex("dbo.i_RegArchitect", new[] { "RegArchitectId" });
            DropIndex("dbo.i_RegArchitect", new[] { "htmlID" });
            DropIndex("dbo.i_PsychologicalSociety", new[] { "addtime" });
            DropIndex("dbo.i_PsychologicalSociety", new[] { "Name_Cn" });
            DropIndex("dbo.i_PsychologicalSociety", new[] { "Name_En" });
            DropIndex("dbo.i_PsychologicalSociety", new[] { "htmlID" });
            DropIndex("dbo.i_InstituteSurveyors", new[] { "addtime" });
            DropIndex("dbo.i_InstituteSurveyors", new[] { "CompanyName" });
            DropIndex("dbo.i_InstituteSurveyors", new[] { "htmlID" });
            DropIndex("dbo.i_GovPhonebook", new[] { "addtime" });
            DropIndex("dbo.i_GovPhonebook", new[] { "htmlID" });
            DropIndex("dbo.i_BuildingCom", new[] { "addtime" });
            DropIndex("dbo.i_BuildingCom", new[] { "CompanyNameEn" });
            DropIndex("dbo.i_BuildingCom", new[] { "BuildingComID" });
            DropIndex("dbo.i_BuildingCom", new[] { "htmlID" });
            DropIndex("dbo.i_Barristers", new[] { "addtime" });
            DropIndex("dbo.i_Barristers", new[] { "htmlID" });
            DropIndex("dbo.i_Architect", new[] { "addtime" });
            DropIndex("dbo.i_Architect", new[] { "MembershipEn" });
            DropIndex("dbo.i_Architect", new[] { "ArchitectId" });
            DropIndex("dbo.i_Architect", new[] { "htmlID" });
            DropIndex("dbo.entityCommMain", new[] { "addtime" });
            DropTable("dbo.m_RatioDecidendis");
            DropTable("dbo.m_parameter");
            DropTable("dbo.m_CompaniesRegistry_itemsChange");
            DropTable("dbo.m_CompaniesRegistry_main");
            DropTable("dbo.m_CompaniesRegistry_items");
            DropTable("dbo.m_CompaniesRegistry_DisOrders");
            DropTable("dbo.m_Case_main");
            DropTable("dbo.m_Case_items");
            DropTable("dbo.m_AppealCases");
            DropTable("dbo.i_ForeignLawyers");
            DropTable("dbo.i_WithCertLawyers");
            DropTable("dbo.i_SecurityBureau");
            DropTable("dbo.i_Secretaries");
            DropTable("dbo.i_RegPharmacist");
            DropTable("dbo.i_RegBuildingCom");
            DropTable("dbo.i_RegArchitect");
            DropTable("dbo.i_PsychologicalSociety");
            DropTable("dbo.i_InstituteSurveyors");
            DropTable("dbo.i_GovPhonebook");
            DropTable("dbo.i_BuildingCom");
            DropTable("dbo.i_Barristers");
            DropTable("dbo.i_Architect");
            DropTable("dbo.entityCommMain");
        }
    }
}

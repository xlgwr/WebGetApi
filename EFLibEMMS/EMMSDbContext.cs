namespace EFLibEMMS.EMMS
{
    using Common.Logging;

    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Reflection;
    public partial class EMMSDbContext : DbContext
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public EMMSDbContext()
            : base("name=EMMS")
        {
            //this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Database.Log = message => logger.DebugFormat(message);//.Replace("\n", " ")
        }

        public virtual DbSet<m_ContactPerson> m_ContactPerson { get; set; }
        public virtual DbSet<m_Country> m_Country { get; set; }
        public virtual DbSet<m_DataGrade> m_DataGrade { get; set; }
        public virtual DbSet<m_Member> m_Member { get; set; }
        public virtual DbSet<m_MemberComany> m_MemberComany { get; set; }
        public virtual DbSet<m_MemberGrade> m_MemberGrade { get; set; }
        public virtual DbSet<m_MemberRight> m_MemberRight { get; set; }
        public virtual DbSet<m_MemberSetMealRelation> m_MemberSetMealRelation { get; set; }
        public virtual DbSet<m_Package> m_Package { get; set; }
        public virtual DbSet<m_PackageList> m_PackageList { get; set; }
        public virtual DbSet<m_Parameter> m_Parameter { get; set; }
        public virtual DbSet<m_Product> m_Product { get; set; }
        public virtual DbSet<m_ProductTable> m_ProductTable { get; set; }
        public virtual DbSet<m_RightKey> m_RightKey { get; set; }
        public virtual DbSet<m_SetEmail> m_SetEmail { get; set; }
        public virtual DbSet<m_ShortName> m_ShortName { get; set; }
        public virtual DbSet<m_SysModule> m_SysModule { get; set; }
        public virtual DbSet<m_SysModuleDetail> m_SysModuleDetail { get; set; }
        public virtual DbSet<m_Table> m_Table { get; set; }
        public virtual DbSet<m_TableField> m_TableField { get; set; }
        public virtual DbSet<m_URL> m_URL { get; set; }
        public virtual DbSet<m_User> m_User { get; set; }
        public virtual DbSet<m_UserAuthority> m_UserAuthority { get; set; }
        public virtual DbSet<m_UserDataRelation> m_UserDataRelation { get; set; }
        public virtual DbSet<m_UserGrade> m_UserGrade { get; set; }
        public virtual DbSet<m_Word> m_Word { get; set; }
        public virtual DbSet<s_Company> s_Company { get; set; }
        public virtual DbSet<t_HtmlPage> t_HtmlPage { get; set; }
        public virtual DbSet<s_Entity> s_Entity { get; set; }
        public virtual DbSet<s_Person> s_Person { get; set; }
        public virtual DbSet<s_Unknown> s_Unknown { get; set; }
        public virtual DbSet<t_Address> t_Address { get; set; }
        public virtual DbSet<t_AppealCase> t_AppealCase { get; set; }
        public virtual DbSet<t_ApplyOfflineCase> t_ApplyOfflineCase { get; set; }
        public virtual DbSet<t_ApplyOfflineCompany> t_ApplyOfflineCompany { get; set; }
        public virtual DbSet<t_ApplyOfflineLand> t_ApplyOfflineLand { get; set; }
        public virtual DbSet<t_ApplyOfflineLoan> t_ApplyOfflineLoan { get; set; }
        public virtual DbSet<t_ApplyOfflineOther> t_ApplyOfflineOther { get; set; }
        public virtual DbSet<t_ApplyOfflinePublic> t_ApplyOfflinePublic { get; set; }
        public virtual DbSet<t_ApplySouch> t_ApplySouch { get; set; }
        public virtual DbSet<t_BankAccount> t_BankAccount { get; set; }
        public virtual DbSet<t_Case> t_Case { get; set; }
        public virtual DbSet<t_CaseType> t_CaseType { get; set; }
        public virtual DbSet<t_Collateral> t_Collateral { get; set; }
        public virtual DbSet<t_CollateralShare> t_CollateralShare { get; set; }
        public virtual DbSet<t_CompanyChange> t_CompanyChange { get; set; }
        public virtual DbSet<t_CompanyReport> t_CompanyReport { get; set; }
        public virtual DbSet<t_Court> t_Court { get; set; }
        public virtual DbSet<t_D_Representation> t_D_Representation { get; set; }
        public virtual DbSet<t_Defendant> t_Defendant { get; set; }
        public virtual DbSet<t_Directors> t_Directors { get; set; }
        public virtual DbSet<t_Disqualification> t_Disqualification { get; set; }
        public virtual DbSet<t_DownLoadReport> t_DownLoadReport { get; set; }
        public virtual DbSet<t_Education> t_Education { get; set; }
        public virtual DbSet<t_EmailList> t_EmailList { get; set; }
        public virtual DbSet<t_Emails> t_Emails { get; set; }
        public virtual DbSet<t_EmploymentHistory> t_EmploymentHistory { get; set; }
        public virtual DbSet<t_IDDocuments> t_IDDocuments { get; set; }
        public virtual DbSet<t_Incumbrances> t_Incumbrances { get; set; }
        public virtual DbSet<t_Invoice> t_Invoice { get; set; }
        public virtual DbSet<t_InvoiceList> t_InvoiceList { get; set; }
        public virtual DbSet<t_Judge> t_Judge { get; set; }
        public virtual DbSet<t_Judgment> t_Judgment { get; set; }
        public virtual DbSet<t_Land> t_Land { get; set; }
        public virtual DbSet<t_Loan> t_Loan { get; set; }
        public virtual DbSet<t_LogRecord> t_LogRecord { get; set; }
        public virtual DbSet<t_MediaReport> t_MediaReport { get; set; }
        public virtual DbSet<t_Message> t_Message { get; set; }
        public virtual DbSet<t_Order> t_Order { get; set; }
        public virtual DbSet<t_OrderList> t_OrderList { get; set; }
        public virtual DbSet<t_OwnerRelation> t_OwnerRelation { get; set; }
        public virtual DbSet<t_P_Representation> t_P_Representation { get; set; }
        public virtual DbSet<t_Payment> t_Payment { get; set; }
        public virtual DbSet<t_Plaintiff> t_Plaintiff { get; set; }
        public virtual DbSet<t_PublicData> t_PublicData { get; set; }
        public virtual DbSet<t_PublicRelation> t_PublicRelation { get; set; }
        public virtual DbSet<t_Quote> t_Quote { get; set; }
        public virtual DbSet<t_QuoteList> t_QuoteList { get; set; }
        public virtual DbSet<t_RatioDecidendi> t_RatioDecidendi { get; set; }
        public virtual DbSet<t_Recipient> t_Recipient { get; set; }
        public virtual DbSet<t_Relationships> t_Relationships { get; set; }
        public virtual DbSet<t_ReportAutoMonitoring> t_ReportAutoMonitoring { get; set; }
        public virtual DbSet<t_ReportOfflineCase> t_ReportOfflineCase { get; set; }
        public virtual DbSet<t_ReportOfflineCom> t_ReportOfflineCom { get; set; }
        public virtual DbSet<t_ReportOfflineLand> t_ReportOfflineLand { get; set; }
        public virtual DbSet<t_ReportOfflineLoan> t_ReportOfflineLoan { get; set; }
        public virtual DbSet<t_ReportOfflineOther> t_ReportOfflineOther { get; set; }
        public virtual DbSet<t_ReportOfflinePublic> t_ReportOfflinePublic { get; set; }
        public virtual DbSet<t_ReportOnlineCase> t_ReportOnlineCase { get; set; }
        public virtual DbSet<t_ReportOnlineCom> t_ReportOnlineCom { get; set; }
        public virtual DbSet<t_ReportOnlineLand> t_ReportOnlineLand { get; set; }
        public virtual DbSet<t_ReportOnlineLoan> t_ReportOnlineLoan { get; set; }
        public virtual DbSet<t_ResultAutoMonitoring> t_ResultAutoMonitoring { get; set; }
        public virtual DbSet<t_ResultOfflineCase> t_ResultOfflineCase { get; set; }
        public virtual DbSet<t_ResultOfflineCom> t_ResultOfflineCom { get; set; }
        public virtual DbSet<t_ResultOfflineLand> t_ResultOfflineLand { get; set; }
        public virtual DbSet<t_ResultOfflineLoan> t_ResultOfflineLoan { get; set; }
        public virtual DbSet<t_ResultOfflineOther> t_ResultOfflineOther { get; set; }
        public virtual DbSet<t_ResultOfflinePublic> t_ResultOfflinePublic { get; set; }
        public virtual DbSet<t_ResultOnlineCase> t_ResultOnlineCase { get; set; }
        public virtual DbSet<t_ResultOnlineCom> t_ResultOnlineCom { get; set; }
        public virtual DbSet<t_ResultOnlineLand> t_ResultOnlineLand { get; set; }
        public virtual DbSet<t_Shareholders> t_Shareholders { get; set; }
        public virtual DbSet<t_SocialNetwork> t_SocialNetwork { get; set; }
        public virtual DbSet<t_TaskAutoGroup> t_TaskAutoGroup { get; set; }
        public virtual DbSet<t_TaskAutoList> t_TaskAutoList { get; set; }
        public virtual DbSet<t_TaskAutoMonitoring> t_TaskAutoMonitoring { get; set; }
        public virtual DbSet<t_TaskOfflineCase> t_TaskOfflineCase { get; set; }
        public virtual DbSet<t_TaskOfflineCompany> t_TaskOfflineCompany { get; set; }
        public virtual DbSet<t_TaskOfflineLand> t_TaskOfflineLand { get; set; }
        public virtual DbSet<t_TaskOfflineLoan> t_TaskOfflineLoan { get; set; }
        public virtual DbSet<t_TaskOfflineOther> t_TaskOfflineOther { get; set; }
        public virtual DbSet<t_TaskOnlineCase> t_TaskOnlineCase { get; set; }
        public virtual DbSet<t_TaskOnlineCompany> t_TaskOnlineCompany { get; set; }
        public virtual DbSet<t_TaskOnlineLand> t_TaskOnlineLand { get; set; }
        public virtual DbSet<t_TaskOnlineLoan> t_TaskOnlineLoan { get; set; }
        public virtual DbSet<t_TaskOnlinePublic> t_TaskOnlinePublic { get; set; }
        public virtual DbSet<t_Telephones> t_Telephones { get; set; }
        public virtual DbSet<t_UpdateLog> t_UpdateLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<m_Member>()
                .HasMany(e => e.t_ApplySouch)
                .WithRequired(e => e.m_Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<m_Member>()
                .HasMany(e => e.t_Payment)
                .WithRequired(e => e.m_Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<m_Member>()
                .HasMany(e => e.t_Invoice)
                .WithRequired(e => e.m_Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<m_Member>()
                .HasMany(e => e.t_Order)
                .WithRequired(e => e.m_Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<m_Member>()
                .HasMany(e => e.t_Quote)
                .WithRequired(e => e.m_Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<m_Member>()
                .HasMany(e => e.t_Recipient)
                .WithRequired(e => e.m_Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<m_Package>()
                .HasMany(e => e.m_MemberSetMealRelation)
                .WithRequired(e => e.m_Package)
                .HasForeignKey(e => e.SetMealID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<m_Package>()
                .HasMany(e => e.t_OrderList)
                .WithOptional(e => e.m_Package)
                .HasForeignKey(e => e.SetMealID);

            modelBuilder.Entity<m_SysModule>()
                .HasMany(e => e.m_SysModuleDetail)
                .WithRequired(e => e.m_SysModule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<m_SysModuleDetail>()
                .HasMany(e => e.m_UserAuthority)
                .WithRequired(e => e.m_SysModuleDetail)
                .HasForeignKey(e => new { e.Mod_id, e.Opr_code })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<m_User>()
                .HasMany(e => e.t_Message)
                .WithRequired(e => e.m_User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<m_UserGrade>()
                .HasMany(e => e.m_UserAuthority)
                .WithRequired(e => e.m_UserGrade)
                .WillCascadeOnDelete(false);           

            modelBuilder.Entity<s_Person>()
                .HasMany(e => e.t_Directors)
                .WithOptional(e => e.s_Person)
                .HasForeignKey(e => e.Entityid_P);

            modelBuilder.Entity<s_Person>()
                .HasMany(e => e.t_Shareholders)
                .WithOptional(e => e.s_Person)
                .HasForeignKey(e => e.Entityid_P);

            modelBuilder.Entity<t_ApplySouch>()
                .HasMany(e => e.t_Quote)
                .WithRequired(e => e.t_ApplySouch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_Case>()
                .Property(e => e.Plaintiff)
                .IsUnicode(false);

            modelBuilder.Entity<t_Case>()
                .Property(e => e.Defendant)
                .IsUnicode(false);

            modelBuilder.Entity<t_Case>()
                .Property(e => e.Representation)
                .IsUnicode(false);

            modelBuilder.Entity<t_Case>()
                .HasMany(e => e.t_Plaintiff)
                .WithRequired(e => e.t_Case)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_Court>()
                .HasMany(e => e.t_Case)
                .WithRequired(e => e.t_Court)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_EmailList>()
                .Property(e => e.EmailBody)
                .IsUnicode(false);

            modelBuilder.Entity<t_MediaReport>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<t_Message>()
                .HasMany(e => e.t_Recipient)
                .WithRequired(e => e.t_Message)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_PublicData>()
                .HasMany(e => e.t_PublicRelation)
                .WithRequired(e => e.t_PublicData)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_Quote>()
                .HasMany(e => e.t_QuoteList)
                .WithRequired(e => e.t_Quote)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_RatioDecidendi>()
                .Property(e => e.Results)
                .IsUnicode(false);

            modelBuilder.Entity<t_TaskAutoMonitoring>()
                .HasMany(e => e.t_TaskAutoGroup)
                .WithRequired(e => e.t_TaskAutoMonitoring)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_TaskOfflineCase>()
                .HasMany(e => e.t_ReportOfflineCase)
                .WithRequired(e => e.t_TaskOfflineCase)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_TaskOfflineCompany>()
                .HasMany(e => e.t_ReportOfflineCom)
                .WithRequired(e => e.t_TaskOfflineCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_TaskOfflineLand>()
                .HasMany(e => e.t_ReportOfflineLand)
                .WithRequired(e => e.t_TaskOfflineLand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_TaskOfflineLoan>()
                .HasMany(e => e.t_ReportOfflineLoan)
                .WithRequired(e => e.t_TaskOfflineLoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_TaskOfflineOther>()
                .HasMany(e => e.t_ReportOfflineOther)
                .WithRequired(e => e.t_TaskOfflineOther)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_TaskOnlineCase>()
                .HasMany(e => e.t_ReportOnlineCase)
                .WithRequired(e => e.t_TaskOnlineCase)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_TaskOnlineCompany>()
                .HasMany(e => e.t_ReportOnlineCom)
                .WithRequired(e => e.t_TaskOnlineCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_TaskOnlineLand>()
                .HasMany(e => e.t_ReportOnlineLand)
                .WithRequired(e => e.t_TaskOnlineLand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_TaskOnlineLoan>()
                .HasMany(e => e.t_ReportOnlineLoan)
                .WithRequired(e => e.t_TaskOnlineLoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_TaskOnlinePublic>()
                .HasMany(e => e.t_ReportOfflinePublic)
                .WithRequired(e => e.t_TaskOnlinePublic)
                .WillCascadeOnDelete(false);
        }
    }
}

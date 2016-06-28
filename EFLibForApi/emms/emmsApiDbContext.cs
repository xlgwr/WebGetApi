namespace EFLibForApi.emms
{
    using Common.Logging;
    using EFLibForApi.emms.models;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection;

    public class emmsApiDbContext : DbContext
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“Model1”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“EFLibForApi.emms.Model1”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“Model1”
        //连接字符串。
        public emmsApiDbContext()
            : base("name=emmsapiConnection")
        {
            //this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Database.Log = message => logger.DebugFormat(message);//.Replace("\n", " ")
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        //public virtual DbSet<m_CompaniesRegistry_main> m_CompaniesRegistry_main { get; set; }
        //public virtual DbSet<m_CompaniesRegistry_items> m_CompaniesRegistry_items { get; set; }
        //public virtual DbSet<m_CompaniesRegistry_itemsChange> m_CompaniesRegistry_itemsChange { get; set; }
        //public virtual DbSet<m_CompaniesRegistry_DisOrders> m_CompaniesRegistry_DisOrders { get; set; }

        public virtual DbSet<m_Case_main> m_Case_main { get; set; }
        public virtual DbSet<m_Case_items> m_Case_items { get; set; }


        public virtual DbSet<m_AppealCases> m_AppealCases { get; set; }
        public virtual DbSet<m_RatioDecidendis> m_RatioDecidendis { get; set; }

        //公共主表
        public virtual DbSet<entityCommMain> entityCommMain { get; set; }

        public virtual DbSet<i_WithCertLawyers> i_WithCertLawyers { get; set; }
        public virtual DbSet<i_ForeignLawyers> i_ForeignLawyers { get; set; }

        public virtual DbSet<i_Barristers> i_Barristers { get; set; }
        public virtual DbSet<i_GovPhonebook> i_GovPhonebook { get; set; }
        public virtual DbSet<i_RegPharmacist> i_RegPharmacist { get; set; }
        public virtual DbSet<i_InstituteSurveyors> i_InstituteSurveyors { get; set; }
        public virtual DbSet<i_PsychologicalSociety> i_PsychologicalSociety { get; set; }
        public virtual DbSet<i_RegBuildingCom> i_RegBuildingCom { get; set; }
        public virtual DbSet<i_RegArchitect> i_RegArchitect { get; set; }
        public virtual DbSet<i_Architect> i_Architect { get; set; }
        public virtual DbSet<i_BuildingCom> i_BuildingCom { get; set; }
        public virtual DbSet<i_SecurityBureau> i_SecurityBureau { get; set; }
        public virtual DbSet<i_Secretaries> i_Secretaries { get; set; }



        public virtual DbSet<m_parameter> m_parameter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<entityCommMain>()
                .Property(e => e.Remark)
                .IsUnicode(false);
            

            //modelBuilder.Entity<m_Case_main>()
            //  .HasRequired(t => t.gwd_Case_items)
            //    .WithRequiredPrincipal(t => t.gwd_Case_main);

        }
        public static emmsApiDbContext Create()
        {
            return new emmsApiDbContext();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}


}
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

        public virtual DbSet<gwd_CompaniesRegistry_main> gwd_CompaniesRegistry_main { get; set; }
        public virtual DbSet<gwd_CompaniesRegistry_items> gwd_CompaniesRegistry_items { get; set; }
        public virtual DbSet<gwd_CompaniesRegistry_itemsChange> gwd_CompaniesRegistry_itemsChange { get; set; }
        public virtual DbSet<gwd_CompaniesRegistry_DisOrders> gwd_CompaniesRegistry_DisOrders { get; set; }

        public virtual DbSet<gwd_Case_main> gwd_Case_main { get; set; }
        public virtual DbSet<gwd_Case_items> gwd_Case_items { get; set; }


        public virtual DbSet<gwd_AppealCases> gwd_AppealCases { get; set; }
        public virtual DbSet<gwd_RatioDecidendis> gwd_RatioDecidendis { get; set; }

        //公共主表
        public virtual DbSet<entityCommMain> entityCommMain { get; set; }

        public virtual DbSet<gwd_Lawyers_items> gwd_Lawyers_items { get; set; }
        public virtual DbSet<gwd_Barristers_items> gwd_Barristers_items { get; set; }
        public virtual DbSet<gwd_GovernmentPhonebook_items> gwd_GovernmentPhonebook_items { get; set; }
        public virtual DbSet<gwd_RegisteredPharmacists_items> gwd_RegisteredPharmacists_items { get; set; }
        public virtual DbSet<gwd_InstituteSurveyors_items> gwd_InstituteSurveyors_items { get; set; }
        public virtual DbSet<gwd_PsychologistsList_items> gwd_PsychologistsList_items { get; set; }
        public virtual DbSet<gwd_RegBuildingCompany_items> gwd_RegBuildingCompany_items { get; set; }
        public virtual DbSet<gwd_RegArchitect_items> gwd_RegArchitect_items { get; set; }
        public virtual DbSet<gwd_architect_items> gwd_architect_items { get; set; }
        public virtual DbSet<gwd_ConstructionCompany_items> gwd_ConstructionCompany_items { get; set; }
        public virtual DbSet<gwd_SecurityBureau_items> gwd_SecurityBureau_items { get; set; }



        public virtual DbSet<m_parameter> m_parameter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<entityCommMain>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<gwd_CompaniesRegistry_main>()
            .Property(e => e.Remark)
            .IsUnicode(false);
            modelBuilder.Entity<gwd_CompaniesRegistry_items>()
            .Property(e => e.Remark)
            .IsUnicode(false);
            modelBuilder.Entity<gwd_CompaniesRegistry_itemsChange>()
            .Property(e => e.Remark)
            .IsUnicode(false);
            modelBuilder.Entity<gwd_CompaniesRegistry_DisOrders>()
            .Property(e => e.Remark)
            .IsUnicode(false);


            modelBuilder.Entity<gwd_Case_main>()
            .Property(e => e.Remark)
            .IsUnicode(false);
            modelBuilder.Entity<gwd_Case_items>()
              .Property(e => e.Remark)
              .IsUnicode(false);

            modelBuilder.Entity<gwd_AppealCases>()
            .Property(e => e.Remark)
            .IsUnicode(false);

            modelBuilder.Entity<gwd_RatioDecidendis>()
            .Property(e => e.Remark)
            .IsUnicode(false);

            modelBuilder.Entity<gwd_Lawyers_items>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<gwd_Barristers_items>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<gwd_GovernmentPhonebook_items>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            //modelBuilder.Entity<gwd_Case_main>()
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
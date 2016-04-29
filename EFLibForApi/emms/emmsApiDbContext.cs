﻿namespace EFLibForApi.emms
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

        public virtual DbSet<gwd_ICRIS_main> gwd_ICRIS_main { get; set; }
        public virtual DbSet<gwd_ICRIS_items> gwd_ICRIS_items { get; set; }
        public virtual DbSet<gwd_ICRIS_itemsChange> gwd_ICRIS_itemsChange { get; set; }
        public virtual DbSet<gwd_ICRIS_DisOrders> gwd_ICRIS_DisOrders { get; set; }

        public virtual DbSet<gwd_Judiciary_main> gwd_Judiciary_main { get; set; }
        public virtual DbSet<gwd_Judiciary_items> gwd_Judiciary_items { get; set; }


        public virtual DbSet<gwd_legalref_main> gwd_legalref_main { get; set; }

        public virtual DbSet<gwd_hklawsoc_main> gwd_hklawsoc_main { get; set; }
        public virtual DbSet<gwd_hklawsoc_items> gwd_hklawsoc_items { get; set; }

        public virtual DbSet<gwd_hkba_main> gwd_hkba_main { get; set; }
        public virtual DbSet<gwd_hkba_items> gwd_hkba_items { get; set; }

        public virtual DbSet<gwd_directory_main> gwd_directory_main { get; set; }
        public virtual DbSet<gwd_directory_items> gwd_directory_items { get; set; }

        public virtual DbSet<m_parameter> m_parameter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<entityMainComm>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<gwd_ICRIS_main>()
            .Property(e => e.Remark)
            .IsUnicode(false);
            modelBuilder.Entity<gwd_ICRIS_items>()
            .Property(e => e.Remark)
            .IsUnicode(false);
            modelBuilder.Entity<gwd_ICRIS_itemsChange>()
            .Property(e => e.Remark)
            .IsUnicode(false);
            modelBuilder.Entity<gwd_ICRIS_DisOrders>()
            .Property(e => e.Remark)
            .IsUnicode(false);


            modelBuilder.Entity<gwd_Judiciary_main>()
            .Property(e => e.Remark)
            .IsUnicode(false);
            modelBuilder.Entity<gwd_Judiciary_items>()
              .Property(e => e.Remark)
              .IsUnicode(false);

            modelBuilder.Entity<gwd_legalref_main>()
            .Property(e => e.Remark)
            .IsUnicode(false);

            modelBuilder.Entity<gwd_hklawsoc_items>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<gwd_hkba_items>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<gwd_directory_items>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            //modelBuilder.Entity<gwd_Judiciary_main>()
            //  .HasRequired(t => t.gwd_Judiciary_items)
            //    .WithRequiredPrincipal(t => t.gwd_Judiciary_main);

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
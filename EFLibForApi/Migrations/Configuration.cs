namespace EFLibForApi.Migrations
{
    using EFLibForApi.emms.models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFLibForApi.emms.emmsApiDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFLibForApi.emms.emmsApiDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            try
            {
                //context.GetWebDatas.AddOrUpdate(
                //     p => p.tname,
                //     new GetWebDatas
                //        {
                //            tname = "T000001",
                //            ttype = "test",
                //            UpdateDate = DateTime.Now,
                //            GetWebDatas_ICRIS = null
                //        },
                //    new GetWebDatas
                //        {
                //            tname = "T000002",
                //            ttype = "test",
                //            UpdateDate = DateTime.Now,
                //            GetWebDatas_ICRIS = null
                //        },
                //    new GetWebDatas
                //        {
                //            tname = "T000003",
                //            ttype = "test",
                //            UpdateDate = DateTime.Now,
                //            GetWebDatas_ICRIS = null
                //        },
                //    new GetWebDatas
                //        {
                //            tname = "T000004",
                //            ttype = "test",
                //            UpdateDate = DateTime.Now,
                //            GetWebDatas_ICRIS = null
                //        }
                // );

                //context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

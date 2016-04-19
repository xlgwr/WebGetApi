namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIndexForAllAddDate : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.gwd_ICRIS_items", "addDate");
            CreateIndex("dbo.gwd_ICRIS_main", "addDate");
            CreateIndex("dbo.gwd_Judiciary_items", "addDate");
            CreateIndex("dbo.gwd_Judiciary_main", "addDate");
            CreateIndex("dbo.m_parameter", "addDate");
        }
        
        public override void Down()
        {
            DropIndex("dbo.m_parameter", new[] { "addDate" });
            DropIndex("dbo.gwd_Judiciary_main", new[] { "addDate" });
            DropIndex("dbo.gwd_Judiciary_items", new[] { "addDate" });
            DropIndex("dbo.gwd_ICRIS_main", new[] { "addDate" });
            DropIndex("dbo.gwd_ICRIS_items", new[] { "addDate" });
        }
    }
}

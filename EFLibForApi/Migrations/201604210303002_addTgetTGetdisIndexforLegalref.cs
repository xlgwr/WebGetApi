namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTgetTGetdisIndexforLegalref : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.gwd_legalref_main", "TGetDis");
        }
        
        public override void Down()
        {
            DropIndex("dbo.gwd_legalref_main", new[] { "TGetDis" });
        }
    }
}

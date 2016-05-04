namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDisStable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.gwd_RatioDecidendis", "TDis", c => c.Long(nullable: false));
            AddColumn("dbo.gwd_RatioDecidendis", "TGetDis", c => c.Long(nullable: false));
            CreateIndex("dbo.gwd_RatioDecidendis", "TDis");
            CreateIndex("dbo.gwd_RatioDecidendis", "TGetDis");
        }
        
        public override void Down()
        {
            DropIndex("dbo.gwd_RatioDecidendis", new[] { "TGetDis" });
            DropIndex("dbo.gwd_RatioDecidendis", new[] { "TDis" });
            DropColumn("dbo.gwd_RatioDecidendis", "TGetDis");
            DropColumn("dbo.gwd_RatioDecidendis", "TDis");
        }
    }
}

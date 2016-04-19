namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTindexForJudicicary : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.gwd_Judiciary_items", "Tid", "dbo.gwd_Judiciary_main");
            DropPrimaryKey("dbo.gwd_Judiciary_items");
            AddColumn("dbo.gwd_Judiciary_items", "Tindex", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.gwd_Judiciary_items", new[] { "Tid", "Tindex" });
            AddForeignKey("dbo.gwd_Judiciary_items", "Tid", "dbo.gwd_Judiciary_main", "Tid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.gwd_Judiciary_items", "Tid", "dbo.gwd_Judiciary_main");
            DropPrimaryKey("dbo.gwd_Judiciary_items");
            DropColumn("dbo.gwd_Judiciary_items", "Tindex");
            AddPrimaryKey("dbo.gwd_Judiciary_items", "Tid");
            AddForeignKey("dbo.gwd_Judiciary_items", "Tid", "dbo.gwd_Judiciary_main", "Tid");
        }
    }
}

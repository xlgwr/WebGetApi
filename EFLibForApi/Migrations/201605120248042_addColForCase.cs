namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColForCase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.gwd_Case_items", "Actiondate", c => c.String());
            AddColumn("dbo.gwd_Case_items", "Currency", c => c.String());
            AddColumn("dbo.gwd_Case_items", "Amount", c => c.String());
            AddColumn("dbo.gwd_Case_items", "CheckField", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.gwd_Case_items", "CheckField");
            DropColumn("dbo.gwd_Case_items", "Amount");
            DropColumn("dbo.gwd_Case_items", "Currency");
            DropColumn("dbo.gwd_Case_items", "Actiondate");
        }
    }
}

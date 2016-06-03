namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPartiesForCaseTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.gwd_Case_items", "Parties", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.gwd_Case_items", "Parties");
        }
    }
}

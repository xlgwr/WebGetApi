namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestChange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.gwd_2legalref_items", newName: "gwd_legalref_items");
            RenameTable(name: "dbo.gwd_2legalref_main", newName: "gwd_legalref_main");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.gwd_legalref_main", newName: "gwd_2legalref_main");
            RenameTable(name: "dbo.gwd_legalref_items", newName: "gwd_2legalref_items");
        }
    }
}

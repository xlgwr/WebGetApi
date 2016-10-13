namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRepColPD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.m_Case_items", "Representation_P", c => c.String());
            AddColumn("dbo.m_Case_items", "Representation_D", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.m_Case_items", "Representation_D");
            DropColumn("dbo.m_Case_items", "Representation_P");
        }
    }
}

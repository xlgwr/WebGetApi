namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClientIpForAll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.gwd_ICRIS_items", "ClientIP", c => c.String());
            AddColumn("dbo.gwd_ICRIS_main", "ClientIP", c => c.String());
            AddColumn("dbo.gwd_Judiciary_items", "ClientIP", c => c.String());
            AddColumn("dbo.gwd_Judiciary_main", "ClientIP", c => c.String());
            AddColumn("dbo.gwd_legalref_items", "ClientIP", c => c.String());
            AddColumn("dbo.gwd_legalref_main", "ClientIP", c => c.String());
            AddColumn("dbo.m_parameter", "ClientIP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.m_parameter", "ClientIP");
            DropColumn("dbo.gwd_legalref_main", "ClientIP");
            DropColumn("dbo.gwd_legalref_items", "ClientIP");
            DropColumn("dbo.gwd_Judiciary_main", "ClientIP");
            DropColumn("dbo.gwd_Judiciary_items", "ClientIP");
            DropColumn("dbo.gwd_ICRIS_main", "ClientIP");
            DropColumn("dbo.gwd_ICRIS_items", "ClientIP");
        }
    }
}

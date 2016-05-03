namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeParam : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.m_parameter");
            AlterColumn("dbo.m_parameter", "paramkey", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.m_parameter", "paramvalue", c => c.String(maxLength: 128));
            AlterColumn("dbo.m_parameter", "paramtype", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.m_parameter", "paramkey");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.m_parameter");
            AlterColumn("dbo.m_parameter", "paramtype", c => c.String(maxLength: 16));
            AlterColumn("dbo.m_parameter", "paramvalue", c => c.String(maxLength: 50));
            AlterColumn("dbo.m_parameter", "paramkey", c => c.String(nullable: false, maxLength: 16));
            AddPrimaryKey("dbo.m_parameter", "paramkey");
        }
    }
}

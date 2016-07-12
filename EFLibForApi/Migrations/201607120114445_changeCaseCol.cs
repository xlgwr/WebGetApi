namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeCaseCol : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.m_Case_items", name: "CYear", newName: "Year");
            RenameColumn(table: "dbo.m_Case_items", name: "CaseType", newName: "CaseTypeID");
            AddColumn("dbo.m_Case_items", "P_Address", c => c.String());
            AddColumn("dbo.m_Case_items", "D_Address", c => c.String());
            AddColumn("dbo.m_Case_items", "Other", c => c.String());
            AddColumn("dbo.m_Case_items", "Other1", c => c.String());
            DropColumn("dbo.m_Case_items", "Cause");
            DropColumn("dbo.m_Case_items", "Actiondate");
            DropColumn("dbo.m_Case_items", "CheckField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.m_Case_items", "CheckField", c => c.String());
            AddColumn("dbo.m_Case_items", "Actiondate", c => c.String());
            AddColumn("dbo.m_Case_items", "Cause", c => c.String());
            DropColumn("dbo.m_Case_items", "Other1");
            DropColumn("dbo.m_Case_items", "Other");
            DropColumn("dbo.m_Case_items", "D_Address");
            DropColumn("dbo.m_Case_items", "P_Address");
            RenameColumn(table: "dbo.m_Case_items", name: "CaseTypeID", newName: "CaseType");
            RenameColumn(table: "dbo.m_Case_items", name: "Year", newName: "CYear");
        }
    }
}

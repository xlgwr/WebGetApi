namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delIDForInstitute : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.i_InstituteSurveyors", "InstituteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.i_InstituteSurveyors", "InstituteId", c => c.Long(nullable: false));
        }
    }
}

namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIDForInstitute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.i_InstituteSurveyors", "InstituteId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.i_InstituteSurveyors", "InstituteId");
        }
    }
}

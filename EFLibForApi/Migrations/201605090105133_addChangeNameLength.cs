namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addChangeNameLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.gwd_Barristers_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_Barristers_items", "ttype", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_GovernmentPhonebook_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_GovernmentPhonebook_items", "ttype", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_InstituteSurveyors_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_InstituteSurveyors_items", "ttype", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_Lawyers_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_Lawyers_items", "ttype", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_PsychologistsList_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_PsychologistsList_items", "ttype", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_RegArchitect_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_RegArchitect_items", "ttype", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_RegBuildingCompany_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_RegBuildingCompany_items", "ttype", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_RegisteredPharmacists_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_RegisteredPharmacists_items", "ttype", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_AppealCases", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_AppealCases", "ttype", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_Case_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_Case_items", "ttype", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_CompaniesRegistry_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_CompaniesRegistry_items", "ttype", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_CompaniesRegistry_itemsChange", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_CompaniesRegistry_itemsChange", "ttype", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.gwd_CompaniesRegistry_itemsChange", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_CompaniesRegistry_itemsChange", "tname", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_CompaniesRegistry_items", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_CompaniesRegistry_items", "tname", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_Case_items", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_Case_items", "tname", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_AppealCases", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_AppealCases", "tname", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_RegisteredPharmacists_items", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_RegisteredPharmacists_items", "tname", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_RegBuildingCompany_items", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_RegBuildingCompany_items", "tname", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_RegArchitect_items", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_RegArchitect_items", "tname", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_PsychologistsList_items", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_PsychologistsList_items", "tname", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_Lawyers_items", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_Lawyers_items", "tname", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_InstituteSurveyors_items", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_InstituteSurveyors_items", "tname", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_GovernmentPhonebook_items", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_GovernmentPhonebook_items", "tname", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_Barristers_items", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_Barristers_items", "tname", c => c.String(maxLength: 200));
        }
    }
}

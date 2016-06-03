namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTnameLenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.gwd_architect_items", "tname", c => c.String());
            AlterColumn("dbo.gwd_Barristers_items", "tname", c => c.String());
            AlterColumn("dbo.gwd_ConstructionCompany_items", "tname", c => c.String());
            AlterColumn("dbo.gwd_GovernmentPhonebook_items", "tname", c => c.String());
            AlterColumn("dbo.gwd_InstituteSurveyors_items", "tname", c => c.String());
            AlterColumn("dbo.gwd_Lawyers_items", "tname", c => c.String());
            AlterColumn("dbo.gwd_PsychologistsList_items", "tname", c => c.String());
            AlterColumn("dbo.gwd_RegArchitect_items", "tname", c => c.String());
            AlterColumn("dbo.gwd_RegBuildingCompany_items", "tname", c => c.String());
            AlterColumn("dbo.gwd_RegisteredPharmacists_items", "tname", c => c.String());
            AlterColumn("dbo.gwd_Secretaries_items", "tname", c => c.String());
            AlterColumn("dbo.gwd_SecurityBureau_items", "tname", c => c.String());
            AlterColumn("dbo.gwd_AppealCases", "tname", c => c.String());
            AlterColumn("dbo.gwd_Case_items", "tname", c => c.String());
            //AlterColumn("dbo.gwd_CompaniesRegistry_items", "tname", c => c.String());
            //AlterColumn("dbo.gwd_CompaniesRegistry_itemsChange", "tname", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.gwd_CompaniesRegistry_itemsChange", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_CompaniesRegistry_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_Case_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_AppealCases", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_SecurityBureau_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_Secretaries_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_RegisteredPharmacists_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_RegBuildingCompany_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_RegArchitect_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_PsychologistsList_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_Lawyers_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_InstituteSurveyors_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_GovernmentPhonebook_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_ConstructionCompany_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_Barristers_items", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_architect_items", "tname", c => c.String(maxLength: 500));
        }
    }
}

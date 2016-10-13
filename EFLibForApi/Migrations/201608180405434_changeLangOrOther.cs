namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeLangOrOther : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.entityCommMain", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.i_Architect", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.i_Barristers", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.i_BuildingCom", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.i_ForeignLawyers", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.i_GovPhonebook", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.i_InstituteSurveyors", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.i_PsychologicalSociety", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.i_RegArchitect", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.i_RegBuildingCom", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.i_RegBuildingCom", name: "Emailaddress", newName: "Email");
            RenameColumn(table: "dbo.i_RegBuildingCom", name: "Faxno", newName: "Fax");
            RenameColumn(table: "dbo.i_RegPharmacist", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.i_Secretaries", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.i_SecurityBureau", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.i_WithCertLawyers", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.m_AppealCases", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.m_Case_items", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.m_Case_main", name: "tLang", newName: "Language");
            RenameColumn(table: "dbo.m_RatioDecidendis", name: "tLang", newName: "Language");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.m_RatioDecidendis", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.m_Case_main", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.m_Case_items", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.m_AppealCases", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.i_WithCertLawyers", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.i_SecurityBureau", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.i_Secretaries", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.i_RegPharmacist", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.i_RegBuildingCom", name: "Fax", newName: "Faxno");
            RenameColumn(table: "dbo.i_RegBuildingCom", name: "Email", newName: "Emailaddress");
            RenameColumn(table: "dbo.i_RegBuildingCom", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.i_RegArchitect", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.i_PsychologicalSociety", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.i_InstituteSurveyors", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.i_GovPhonebook", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.i_ForeignLawyers", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.i_BuildingCom", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.i_Barristers", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.i_Architect", name: "Language", newName: "tLang");
            RenameColumn(table: "dbo.entityCommMain", name: "Language", newName: "tLang");
        }
    }
}

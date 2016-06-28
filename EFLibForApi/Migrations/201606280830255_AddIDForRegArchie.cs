namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIDForRegArchie : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.i_RegArchitect", new[] { "RegArchitectId" });
            DropIndex("dbo.i_RegBuildingCom", new[] { "RegBuildingComId" });
            AddColumn("dbo.i_RegArchitect", "RegNo", c => c.String(maxLength: 128));
            AddColumn("dbo.i_RegBuildingCom", "RegNo", c => c.String(maxLength: 128));
            CreateIndex("dbo.i_RegArchitect", "RegNo");
            CreateIndex("dbo.i_RegBuildingCom", "RegNo");
            DropColumn("dbo.i_RegArchitect", "RegArchitectId");
            DropColumn("dbo.i_RegBuildingCom", "RegBuildingComId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.i_RegBuildingCom", "RegBuildingComId", c => c.String(maxLength: 128));
            AddColumn("dbo.i_RegArchitect", "RegArchitectId", c => c.String(maxLength: 128));
            DropIndex("dbo.i_RegBuildingCom", new[] { "RegNo" });
            DropIndex("dbo.i_RegArchitect", new[] { "RegNo" });
            DropColumn("dbo.i_RegBuildingCom", "RegNo");
            DropColumn("dbo.i_RegArchitect", "RegNo");
            CreateIndex("dbo.i_RegBuildingCom", "RegBuildingComId");
            CreateIndex("dbo.i_RegArchitect", "RegArchitectId");
        }
    }
}

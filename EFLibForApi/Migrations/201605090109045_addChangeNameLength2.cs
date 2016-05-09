namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addChangeNameLength2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.entityCommMain", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.entityCommMain", "ttype", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_Case_main", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_Case_main", "ttype", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_CompaniesRegistry_main", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_CompaniesRegistry_main", "ttype", c => c.String(maxLength: 300));
            AlterColumn("dbo.gwd_RatioDecidendis", "tname", c => c.String(maxLength: 500));
            AlterColumn("dbo.gwd_RatioDecidendis", "ttype", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.gwd_RatioDecidendis", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_RatioDecidendis", "tname", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_CompaniesRegistry_main", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_CompaniesRegistry_main", "tname", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_Case_main", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_Case_main", "tname", c => c.String(maxLength: 200));
            AlterColumn("dbo.entityCommMain", "ttype", c => c.String(maxLength: 200));
            AlterColumn("dbo.entityCommMain", "tname", c => c.String(maxLength: 200));
        }
    }
}

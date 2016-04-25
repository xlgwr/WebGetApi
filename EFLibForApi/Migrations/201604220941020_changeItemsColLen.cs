namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeItemsColLen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.gwd_ICRIS_items", "tcomp", c => c.String(unicode: false));
            AlterColumn("dbo.gwd_ICRIS_items", "tclass", c => c.String(unicode: false));
            AlterColumn("dbo.gwd_ICRIS_items", "tStartDate", c => c.String());
            AlterColumn("dbo.gwd_ICRIS_items", "tCompStartDate", c => c.String());
            AlterColumn("dbo.gwd_ICRIS_items", "tCompStart", c => c.String(unicode: false));
            AlterColumn("dbo.gwd_ICRIS_items", "tNows", c => c.String());
            AlterColumn("dbo.gwd_ICRIS_items", "tRemarkNow", c => c.String());
            AlterColumn("dbo.gwd_ICRIS_items", "tModel", c => c.String());
            AlterColumn("dbo.gwd_ICRIS_items", "tCloseDate", c => c.String());
            AlterColumn("dbo.gwd_ICRIS_items", "tSaveBook", c => c.String());
            AlterColumn("dbo.gwd_ICRIS_items", "tImEvens", c => c.String(unicode: false));
            AlterColumn("dbo.gwd_ICRIS_items", "tSearchRes", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.gwd_ICRIS_items", "tSearchRes", c => c.String(maxLength: 100));
            AlterColumn("dbo.gwd_ICRIS_items", "tImEvens", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.gwd_ICRIS_items", "tSaveBook", c => c.String(maxLength: 50));
            AlterColumn("dbo.gwd_ICRIS_items", "tCloseDate", c => c.String(maxLength: 100));
            AlterColumn("dbo.gwd_ICRIS_items", "tModel", c => c.String(maxLength: 100));
            AlterColumn("dbo.gwd_ICRIS_items", "tRemarkNow", c => c.String(maxLength: 200));
            AlterColumn("dbo.gwd_ICRIS_items", "tNows", c => c.String(maxLength: 100));
            AlterColumn("dbo.gwd_ICRIS_items", "tCompStart", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.gwd_ICRIS_items", "tCompStartDate", c => c.String(maxLength: 100));
            AlterColumn("dbo.gwd_ICRIS_items", "tStartDate", c => c.String(maxLength: 100));
            AlterColumn("dbo.gwd_ICRIS_items", "tclass", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.gwd_ICRIS_items", "tcomp", c => c.String(maxLength: 200, unicode: false));
        }
    }
}

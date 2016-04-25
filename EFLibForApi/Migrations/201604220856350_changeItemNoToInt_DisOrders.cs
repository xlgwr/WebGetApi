namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeItemNoToInt_DisOrders : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.gwd_ICRIS_DisOrders", "ItemNo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.gwd_ICRIS_DisOrders", "ItemNo", c => c.String());
        }
    }
}

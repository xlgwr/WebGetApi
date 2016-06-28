namespace EFLibForApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeIBarrisers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.i_Barristers", "Tel", c => c.String());
            DropColumn("dbo.i_Barristers", "Telphone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.i_Barristers", "Telphone", c => c.String());
            DropColumn("dbo.i_Barristers", "Tel");
        }
    }
}

namespace Svapas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllModel19_02_201 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderDateTime");
        }
    }
}

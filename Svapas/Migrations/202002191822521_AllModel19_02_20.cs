namespace Svapas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllModel19_02_20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Clothings",
                c => new
                    {
                        ClothingId = c.Int(nullable: false, identity: true),
                        ClothingName = c.String(),
                        ClothingDem = c.String(),
                        CategoryId = c.Int(nullable: false),
                        ClothingPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClothingId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OrderPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPassword = c.String(),
                        UserFname = c.String(),
                        UserLname = c.String(),
                        UserEmail = c.String(),
                        UserPhone = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.OrderClothings",
                c => new
                    {
                        Order_OrderId = c.Int(nullable: false),
                        Clothing_ClothingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderId, t.Clothing_ClothingId })
                .ForeignKey("dbo.Orders", t => t.Order_OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Clothings", t => t.Clothing_ClothingId, cascadeDelete: true)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Clothing_ClothingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderClothings", "Clothing_ClothingId", "dbo.Clothings");
            DropForeignKey("dbo.OrderClothings", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Clothings", "CategoryId", "dbo.Categories");
            DropIndex("dbo.OrderClothings", new[] { "Clothing_ClothingId" });
            DropIndex("dbo.OrderClothings", new[] { "Order_OrderId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Clothings", new[] { "CategoryId" });
            DropTable("dbo.OrderClothings");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Clothings");
            DropTable("dbo.Categories");
        }
    }
}

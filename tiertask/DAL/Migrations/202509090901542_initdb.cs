namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 8000, unicode: false),
                        Date = c.DateTime(nullable: false),
                        cId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.cId, cascadeDelete: true)
                .Index(t => t.cId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "cId", "dbo.Categories");
            DropIndex("dbo.News", new[] { "cId" });
            DropTable("dbo.News");
            DropTable("dbo.Categories");
        }
    }
}

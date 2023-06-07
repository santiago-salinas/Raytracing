namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PPMEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PixelEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Red = c.Double(nullable: false),
                        Green = c.Double(nullable: false),
                        Blue = c.Double(nullable: false),
                        PPMEntityId = c.Int(nullable: false),
                        ColumnPos = c.Int(nullable: false),
                        RowPos = c.Int(nullable: false),
                        PPMEntity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PPMEntities", t => t.PPMEntity_Id)
                .Index(t => t.PPMEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PixelEntities", "PPMEntity_Id", "dbo.PPMEntities");
            DropIndex("dbo.PixelEntities", new[] { "PPMEntity_Id" });
            DropTable("dbo.PixelEntities");
            DropTable("dbo.PPMEntities");
        }
    }
}

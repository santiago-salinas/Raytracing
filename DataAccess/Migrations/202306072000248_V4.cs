namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PixelEntities", "PPMEntity_Id", "dbo.PPMEntities");
            DropIndex("dbo.PixelEntities", new[] { "PPMEntity_Id" });
            AddColumn("dbo.PPMEntities", "RenderBytes", c => c.Binary());
            DropTable("dbo.PixelEntities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PixelEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Red = c.Double(nullable: false),
                        Green = c.Double(nullable: false),
                        Blue = c.Double(nullable: false),
                        ColumnPos = c.Int(nullable: false),
                        RowPos = c.Int(nullable: false),
                        PPMEntity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.PPMEntities", "RenderBytes");
            CreateIndex("dbo.PixelEntities", "PPMEntity_Id");
            AddForeignKey("dbo.PixelEntities", "PPMEntity_Id", "dbo.PPMEntities", "Id");
        }
    }
}

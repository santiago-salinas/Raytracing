namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V41 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PositionedModelEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PositionX = c.Double(nullable: false),
                        PositionY = c.Double(nullable: false),
                        PositionZ = c.Double(nullable: false),
                        Model_Name = c.String(maxLength: 128),
                        Model_OwnerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModelEntities", t => new { t.Model_Name, t.Model_OwnerId })
                .Index(t => new { t.Model_Name, t.Model_OwnerId });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PositionedModelEntities", new[] { "Model_Name", "Model_OwnerId" }, "dbo.ModelEntities");
            DropIndex("dbo.PositionedModelEntities", new[] { "Model_Name", "Model_OwnerId" });
            DropTable("dbo.PositionedModelEntities");
        }
    }
}

namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V42 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PositionedModelEntities");
            CreateTable(
                "dbo.CameraEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LookFrom_FirstValue = c.Double(nullable: false),
                        LookFrom_SecondValue = c.Double(nullable: false),
                        LookFrom_ThirdValue = c.Double(nullable: false),
                        LookAt_FirstValue = c.Double(nullable: false),
                        LookAt_SecondValue = c.Double(nullable: false),
                        LookAt_ThirdValue = c.Double(nullable: false),
                        Up_FirstValue = c.Double(nullable: false),
                        Up_SecondValue = c.Double(nullable: false),
                        Up_ThirdValue = c.Double(nullable: false),
                        FieldOfView = c.Int(nullable: false),
                        ResolutionX = c.Int(nullable: false),
                        ResolutionY = c.Int(nullable: false),
                        SamplesPerPixel = c.Int(nullable: false),
                        MaxDepth = c.Int(nullable: false),
                        Aperture = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PositionedModelEntities", "SceneName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.PositionedModelEntities", "SceneName");
            DropColumn("dbo.PositionedModelEntities", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PositionedModelEntities", "Id", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.PositionedModelEntities");
            DropColumn("dbo.PositionedModelEntities", "SceneName");
            DropTable("dbo.CameraEntities");
            AddPrimaryKey("dbo.PositionedModelEntities", "Id");
        }
    }
}

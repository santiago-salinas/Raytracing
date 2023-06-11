namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SceneEntities",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        OwnerId = c.String(nullable: false, maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        LastModificationDate = c.DateTime(nullable: false),
                        LastRenderDate = c.DateTime(nullable: false),
                        Blur = c.Boolean(nullable: false),
                        CameraDTO_Id = c.Guid(),
                    })
                .PrimaryKey(t => new { t.Name, t.OwnerId })
                .ForeignKey("dbo.CameraEntities", t => t.CameraDTO_Id)
                .ForeignKey("dbo.UserEntities", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId)
                .Index(t => t.CameraDTO_Id);
            
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
            
            AddColumn("dbo.PositionedModelEntities", "SceneEntity_Name", c => c.String(maxLength: 128));
            AddColumn("dbo.PositionedModelEntities", "SceneEntity_OwnerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.PositionedModelEntities", new[] { "SceneEntity_Name", "SceneEntity_OwnerId" });
            AddForeignKey("dbo.PositionedModelEntities", new[] { "SceneEntity_Name", "SceneEntity_OwnerId" }, "dbo.SceneEntities", new[] { "Name", "OwnerId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PositionedModelEntities", new[] { "SceneEntity_Name", "SceneEntity_OwnerId" }, "dbo.SceneEntities");
            DropForeignKey("dbo.SceneEntities", "OwnerId", "dbo.UserEntities");
            DropForeignKey("dbo.SceneEntities", "CameraDTO_Id", "dbo.CameraEntities");
            DropIndex("dbo.SceneEntities", new[] { "CameraDTO_Id" });
            DropIndex("dbo.SceneEntities", new[] { "OwnerId" });
            DropIndex("dbo.PositionedModelEntities", new[] { "SceneEntity_Name", "SceneEntity_OwnerId" });
            DropColumn("dbo.PositionedModelEntities", "SceneEntity_OwnerId");
            DropColumn("dbo.PositionedModelEntities", "SceneEntity_Name");
            DropTable("dbo.CameraEntities");
            DropTable("dbo.SceneEntities");
        }
    }
}

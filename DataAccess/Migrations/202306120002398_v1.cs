namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class v1 : DbMigration
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
                    SceneEntity_Name = c.String(maxLength: 128),
                    SceneEntity_OwnerId = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModelEntities", t => new { t.Model_Name, t.Model_OwnerId })
                .ForeignKey("dbo.SceneEntities", t => new { t.SceneEntity_Name, t.SceneEntity_OwnerId })
                .Index(t => new { t.Model_Name, t.Model_OwnerId })
                .Index(t => new { t.SceneEntity_Name, t.SceneEntity_OwnerId });

            CreateTable(
                "dbo.SceneEntities",
                c => new
                {
                    Name = c.String(nullable: false, maxLength: 128),
                    OwnerId = c.String(nullable: false, maxLength: 128),
                    CreationDate = c.DateTime(),
                    LastModificationDate = c.DateTime(),
                    LastRenderDate = c.DateTime(),
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

        }

        public override void Down()
        {
            DropForeignKey("dbo.PositionedModelEntities", new[] { "SceneEntity_Name", "SceneEntity_OwnerId" }, "dbo.SceneEntities");
            DropForeignKey("dbo.SceneEntities", "OwnerId", "dbo.UserEntities");
            DropForeignKey("dbo.SceneEntities", "CameraDTO_Id", "dbo.CameraEntities");
            DropForeignKey("dbo.PositionedModelEntities", new[] { "Model_Name", "Model_OwnerId" }, "dbo.ModelEntities");
            DropIndex("dbo.SceneEntities", new[] { "CameraDTO_Id" });
            DropIndex("dbo.SceneEntities", new[] { "OwnerId" });
            DropIndex("dbo.PositionedModelEntities", new[] { "SceneEntity_Name", "SceneEntity_OwnerId" });
            DropIndex("dbo.PositionedModelEntities", new[] { "Model_Name", "Model_OwnerId" });
            DropTable("dbo.CameraEntities");
            DropTable("dbo.SceneEntities");
            DropTable("dbo.PositionedModelEntities");
        }
    }
}

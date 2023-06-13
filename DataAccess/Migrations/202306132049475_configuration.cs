namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configuration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LambertianEntities",
                c => new
                    {
                        MaterialName = c.String(nullable: false, maxLength: 128),
                        MaterialOwnerId = c.String(nullable: false, maxLength: 128),
                        RedValue = c.Int(nullable: false),
                        GreenValue = c.Int(nullable: false),
                        BlueValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaterialName, t.MaterialOwnerId })
                .ForeignKey("dbo.MaterialEntities", t => new { t.MaterialName, t.MaterialOwnerId })
                .Index(t => new { t.MaterialName, t.MaterialOwnerId });
            
            CreateTable(
                "dbo.MaterialEntities",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        OwnerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Name, t.OwnerId })
                .ForeignKey("dbo.UserEntities", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.MetallicEntities",
                c => new
                    {
                        MaterialName = c.String(nullable: false, maxLength: 128),
                        MaterialOwnerId = c.String(nullable: false, maxLength: 128),
                        RedValue = c.Int(nullable: false),
                        GreenValue = c.Int(nullable: false),
                        BlueValue = c.Int(nullable: false),
                        Roughness = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaterialName, t.MaterialOwnerId })
                .ForeignKey("dbo.MaterialEntities", t => new { t.MaterialName, t.MaterialOwnerId })
                .Index(t => new { t.MaterialName, t.MaterialOwnerId });
            
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.ModelEntities",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        OwnerId = c.String(nullable: false, maxLength: 128),
                        Material_Name = c.String(maxLength: 128),
                        Material_OwnerId = c.String(maxLength: 128),
                        PPMEntity_Id = c.Guid(),
                        Shape_Name = c.String(maxLength: 128),
                        Shape_OwnerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Name, t.OwnerId })
                .ForeignKey("dbo.MaterialEntities", t => new { t.Material_Name, t.Material_OwnerId })
                .ForeignKey("dbo.UserEntities", t => t.OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.PPMEntities", t => t.PPMEntity_Id)
                .ForeignKey("dbo.SphereEntities", t => new { t.Shape_Name, t.Shape_OwnerId })
                .Index(t => t.OwnerId)
                .Index(t => new { t.Material_Name, t.Material_OwnerId })
                .Index(t => t.PPMEntity_Id)
                .Index(t => new { t.Shape_Name, t.Shape_OwnerId });
            
            CreateTable(
                "dbo.PPMEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        RenderBytes = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SphereEntities",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        OwnerId = c.String(nullable: false, maxLength: 128),
                        Radius = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Name, t.OwnerId })
                .ForeignKey("dbo.UserEntities", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
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
                        PPMEntity_Id = c.Guid(),
                    })
                .PrimaryKey(t => new { t.Name, t.OwnerId })
                .ForeignKey("dbo.CameraEntities", t => t.CameraDTO_Id)
                .ForeignKey("dbo.UserEntities", t => t.OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.PPMEntities", t => t.PPMEntity_Id)
                .Index(t => t.OwnerId)
                .Index(t => t.CameraDTO_Id)
                .Index(t => t.PPMEntity_Id);
            
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
            DropForeignKey("dbo.SceneEntities", "PPMEntity_Id", "dbo.PPMEntities");
            DropForeignKey("dbo.PositionedModelEntities", new[] { "SceneEntity_Name", "SceneEntity_OwnerId" }, "dbo.SceneEntities");
            DropForeignKey("dbo.SceneEntities", "OwnerId", "dbo.UserEntities");
            DropForeignKey("dbo.SceneEntities", "CameraDTO_Id", "dbo.CameraEntities");
            DropForeignKey("dbo.PositionedModelEntities", new[] { "Model_Name", "Model_OwnerId" }, "dbo.ModelEntities");
            DropForeignKey("dbo.ModelEntities", new[] { "Shape_Name", "Shape_OwnerId" }, "dbo.SphereEntities");
            DropForeignKey("dbo.SphereEntities", "OwnerId", "dbo.UserEntities");
            DropForeignKey("dbo.ModelEntities", "PPMEntity_Id", "dbo.PPMEntities");
            DropForeignKey("dbo.ModelEntities", "OwnerId", "dbo.UserEntities");
            DropForeignKey("dbo.ModelEntities", new[] { "Material_Name", "Material_OwnerId" }, "dbo.MaterialEntities");
            DropForeignKey("dbo.LambertianEntities", new[] { "MaterialName", "MaterialOwnerId" }, "dbo.MaterialEntities");
            DropForeignKey("dbo.MaterialEntities", "OwnerId", "dbo.UserEntities");
            DropForeignKey("dbo.MetallicEntities", new[] { "MaterialName", "MaterialOwnerId" }, "dbo.MaterialEntities");
            DropIndex("dbo.SceneEntities", new[] { "PPMEntity_Id" });
            DropIndex("dbo.SceneEntities", new[] { "CameraDTO_Id" });
            DropIndex("dbo.SceneEntities", new[] { "OwnerId" });
            DropIndex("dbo.PositionedModelEntities", new[] { "SceneEntity_Name", "SceneEntity_OwnerId" });
            DropIndex("dbo.PositionedModelEntities", new[] { "Model_Name", "Model_OwnerId" });
            DropIndex("dbo.SphereEntities", new[] { "OwnerId" });
            DropIndex("dbo.ModelEntities", new[] { "Shape_Name", "Shape_OwnerId" });
            DropIndex("dbo.ModelEntities", new[] { "PPMEntity_Id" });
            DropIndex("dbo.ModelEntities", new[] { "Material_Name", "Material_OwnerId" });
            DropIndex("dbo.ModelEntities", new[] { "OwnerId" });
            DropIndex("dbo.MetallicEntities", new[] { "MaterialName", "MaterialOwnerId" });
            DropIndex("dbo.MaterialEntities", new[] { "OwnerId" });
            DropIndex("dbo.LambertianEntities", new[] { "MaterialName", "MaterialOwnerId" });
            DropTable("dbo.CameraEntities");
            DropTable("dbo.SceneEntities");
            DropTable("dbo.PositionedModelEntities");
            DropTable("dbo.SphereEntities");
            DropTable("dbo.PPMEntities");
            DropTable("dbo.ModelEntities");
            DropTable("dbo.UserEntities");
            DropTable("dbo.MetallicEntities");
            DropTable("dbo.MaterialEntities");
            DropTable("dbo.LambertianEntities");
        }
    }
}

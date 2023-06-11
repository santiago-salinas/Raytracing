namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Help : DbMigration
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
                        Shape_Name = c.String(maxLength: 128),
                        Shape_OwnerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Name, t.OwnerId })
                .ForeignKey("dbo.MaterialEntities", t => new { t.Material_Name, t.Material_OwnerId })
                .ForeignKey("dbo.UserEntities", t => t.OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.SphereEntities", t => new { t.Shape_Name, t.Shape_OwnerId })
                .Index(t => t.OwnerId)
                .Index(t => new { t.Material_Name, t.Material_OwnerId })
                .Index(t => new { t.Shape_Name, t.Shape_OwnerId });
            
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
                "dbo.PPMEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        RenderBytes = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModelEntities", new[] { "Shape_Name", "Shape_OwnerId" }, "dbo.SphereEntities");
            DropForeignKey("dbo.SphereEntities", "OwnerId", "dbo.UserEntities");
            DropForeignKey("dbo.ModelEntities", "OwnerId", "dbo.UserEntities");
            DropForeignKey("dbo.ModelEntities", new[] { "Material_Name", "Material_OwnerId" }, "dbo.MaterialEntities");
            DropForeignKey("dbo.LambertianEntities", new[] { "MaterialName", "MaterialOwnerId" }, "dbo.MaterialEntities");
            DropForeignKey("dbo.MaterialEntities", "OwnerId", "dbo.UserEntities");
            DropForeignKey("dbo.MetallicEntities", new[] { "MaterialName", "MaterialOwnerId" }, "dbo.MaterialEntities");
            DropIndex("dbo.SphereEntities", new[] { "OwnerId" });
            DropIndex("dbo.ModelEntities", new[] { "Shape_Name", "Shape_OwnerId" });
            DropIndex("dbo.ModelEntities", new[] { "Material_Name", "Material_OwnerId" });
            DropIndex("dbo.ModelEntities", new[] { "OwnerId" });
            DropIndex("dbo.MetallicEntities", new[] { "MaterialName", "MaterialOwnerId" });
            DropIndex("dbo.MaterialEntities", new[] { "OwnerId" });
            DropIndex("dbo.LambertianEntities", new[] { "MaterialName", "MaterialOwnerId" });
            DropTable("dbo.PPMEntities");
            DropTable("dbo.SphereEntities");
            DropTable("dbo.ModelEntities");
            DropTable("dbo.UserEntities");
            DropTable("dbo.MetallicEntities");
            DropTable("dbo.MaterialEntities");
            DropTable("dbo.LambertianEntities");
        }
    }
}

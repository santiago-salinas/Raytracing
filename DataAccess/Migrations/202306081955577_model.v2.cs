namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelv2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ModelEntities");
            AddColumn("dbo.ModelEntities", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ModelEntities", "Material_Name", c => c.String(maxLength: 128));
            AddColumn("dbo.ModelEntities", "Material_OwnerId", c => c.String(maxLength: 128));
            AddColumn("dbo.ModelEntities", "Shape_Name", c => c.String(maxLength: 128));
            AddColumn("dbo.ModelEntities", "Shape_OwnerId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.ModelEntities", new[] { "Name", "OwnerId" });
            CreateIndex("dbo.ModelEntities", "OwnerId");
            CreateIndex("dbo.ModelEntities", new[] { "Material_Name", "Material_OwnerId" });
            CreateIndex("dbo.ModelEntities", new[] { "Shape_Name", "Shape_OwnerId" });
            AddForeignKey("dbo.ModelEntities", new[] { "Material_Name", "Material_OwnerId" }, "dbo.MaterialEntities", new[] { "Name", "OwnerId" });
            AddForeignKey("dbo.ModelEntities", "OwnerId", "dbo.UserEntities", "Username", cascadeDelete: true);
            AddForeignKey("dbo.ModelEntities", new[] { "Shape_Name", "Shape_OwnerId" }, "dbo.SphereEntities", new[] { "Name", "OwnerId" });
            DropColumn("dbo.ModelEntities", "Owner");
            DropColumn("dbo.ModelEntities", "MaterialName");
            DropColumn("dbo.ModelEntities", "ShapeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ModelEntities", "ShapeName", c => c.String());
            AddColumn("dbo.ModelEntities", "MaterialName", c => c.String());
            AddColumn("dbo.ModelEntities", "Owner", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.ModelEntities", new[] { "Shape_Name", "Shape_OwnerId" }, "dbo.SphereEntities");
            DropForeignKey("dbo.ModelEntities", "OwnerId", "dbo.UserEntities");
            DropForeignKey("dbo.ModelEntities", new[] { "Material_Name", "Material_OwnerId" }, "dbo.MaterialEntities");
            DropIndex("dbo.ModelEntities", new[] { "Shape_Name", "Shape_OwnerId" });
            DropIndex("dbo.ModelEntities", new[] { "Material_Name", "Material_OwnerId" });
            DropIndex("dbo.ModelEntities", new[] { "OwnerId" });
            DropPrimaryKey("dbo.ModelEntities");
            DropColumn("dbo.ModelEntities", "Shape_OwnerId");
            DropColumn("dbo.ModelEntities", "Shape_Name");
            DropColumn("dbo.ModelEntities", "Material_OwnerId");
            DropColumn("dbo.ModelEntities", "Material_Name");
            DropColumn("dbo.ModelEntities", "OwnerId");
            AddPrimaryKey("dbo.ModelEntities", new[] { "Name", "Owner" });
        }
    }
}

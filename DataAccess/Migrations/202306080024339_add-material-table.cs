namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmaterialtable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LambertianEntities");
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
                        Roughness = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaterialName, t.MaterialOwnerId })
                .ForeignKey("dbo.MaterialEntities", t => new { t.MaterialName, t.MaterialOwnerId })
                .Index(t => new { t.MaterialName, t.MaterialOwnerId });
            
            AddColumn("dbo.LambertianEntities", "MaterialName", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.LambertianEntities", "MaterialOwnerId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.LambertianEntities", new[] { "MaterialName", "MaterialOwnerId" });
            CreateIndex("dbo.LambertianEntities", new[] { "MaterialName", "MaterialOwnerId" });
            AddForeignKey("dbo.LambertianEntities", new[] { "MaterialName", "MaterialOwnerId" }, "dbo.MaterialEntities", new[] { "Name", "OwnerId" });
            DropColumn("dbo.LambertianEntities", "Name");
            DropColumn("dbo.LambertianEntities", "Owner");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LambertianEntities", "Owner", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.LambertianEntities", "Name", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.MetallicEntities", new[] { "MaterialName", "MaterialOwnerId" }, "dbo.MaterialEntities");
            DropForeignKey("dbo.LambertianEntities", new[] { "MaterialName", "MaterialOwnerId" }, "dbo.MaterialEntities");
            DropForeignKey("dbo.MaterialEntities", "OwnerId", "dbo.UserEntities");
            DropIndex("dbo.MetallicEntities", new[] { "MaterialName", "MaterialOwnerId" });
            DropIndex("dbo.MaterialEntities", new[] { "OwnerId" });
            DropIndex("dbo.LambertianEntities", new[] { "MaterialName", "MaterialOwnerId" });
            DropPrimaryKey("dbo.LambertianEntities");
            DropColumn("dbo.LambertianEntities", "MaterialOwnerId");
            DropColumn("dbo.LambertianEntities", "MaterialName");
            DropTable("dbo.MetallicEntities");
            DropTable("dbo.MaterialEntities");
            AddPrimaryKey("dbo.LambertianEntities", new[] { "Name", "Owner" });
        }
    }
}

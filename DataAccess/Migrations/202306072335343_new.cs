namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SphereEntities");
            AddColumn("dbo.SphereEntities", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.SphereEntities", new[] { "Name", "OwnerId" });
            CreateIndex("dbo.SphereEntities", "OwnerId");
            AddForeignKey("dbo.SphereEntities", "OwnerId", "dbo.UserEntities", "Username", cascadeDelete: true);
            DropColumn("dbo.SphereEntities", "Owner");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SphereEntities", "Owner", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.SphereEntities", "OwnerId", "dbo.UserEntities");
            DropIndex("dbo.SphereEntities", new[] { "OwnerId" });
            DropPrimaryKey("dbo.SphereEntities");
            DropColumn("dbo.SphereEntities", "OwnerId");
            AddPrimaryKey("dbo.SphereEntities", new[] { "Name", "Owner" });
        }
    }
}

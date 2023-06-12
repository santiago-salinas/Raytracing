namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SceneEntities", "PPMEntity_Id", c => c.Guid());
            CreateIndex("dbo.SceneEntities", "PPMEntity_Id");
            AddForeignKey("dbo.SceneEntities", "PPMEntity_Id", "dbo.PPMEntities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SceneEntities", "PPMEntity_Id", "dbo.PPMEntities");
            DropIndex("dbo.SceneEntities", new[] { "PPMEntity_Id" });
            DropColumn("dbo.SceneEntities", "PPMEntity_Id");
        }
    }
}

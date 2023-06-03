namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModelEntities",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Owner = c.String(nullable: false, maxLength: 128),
                        MaterialName = c.String(),
                        ShapeName = c.String(),
                    })
                .PrimaryKey(t => new { t.Name, t.Owner });
            
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserEntities");
            DropTable("dbo.ModelEntities");
        }
    }
}

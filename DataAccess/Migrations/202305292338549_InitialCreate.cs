namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SphereEntities",
                c => new
                    {
                        NameID = c.String(nullable: false, maxLength: 128),
                        Owner = c.String(),
                        Radius = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NameID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SphereEntities");
        }
    }
}

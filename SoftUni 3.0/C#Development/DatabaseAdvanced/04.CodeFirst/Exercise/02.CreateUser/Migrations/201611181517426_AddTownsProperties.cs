namespace _02.CreateUser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTownsProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "BornTown_Id", c => c.Int());
            AddColumn("dbo.Users", "LivingTown_Id", c => c.Int());
            AddColumn("dbo.Users", "Town_Id", c => c.Int());
            AddColumn("dbo.Users", "Town_Id1", c => c.Int());
            CreateIndex("dbo.Users", "BornTown_Id");
            CreateIndex("dbo.Users", "LivingTown_Id");
            CreateIndex("dbo.Users", "Town_Id");
            CreateIndex("dbo.Users", "Town_Id1");
            AddForeignKey("dbo.Users", "BornTown_Id", "dbo.Towns", "Id");
            AddForeignKey("dbo.Users", "LivingTown_Id", "dbo.Towns", "Id");
            AddForeignKey("dbo.Users", "Town_Id", "dbo.Towns", "Id");
            AddForeignKey("dbo.Users", "Town_Id1", "dbo.Towns", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Town_Id1", "dbo.Towns");
            DropForeignKey("dbo.Users", "Town_Id", "dbo.Towns");
            DropForeignKey("dbo.Users", "LivingTown_Id", "dbo.Towns");
            DropForeignKey("dbo.Users", "BornTown_Id", "dbo.Towns");
            DropIndex("dbo.Users", new[] { "Town_Id1" });
            DropIndex("dbo.Users", new[] { "Town_Id" });
            DropIndex("dbo.Users", new[] { "LivingTown_Id" });
            DropIndex("dbo.Users", new[] { "BornTown_Id" });
            DropColumn("dbo.Users", "Town_Id1");
            DropColumn("dbo.Users", "Town_Id");
            DropColumn("dbo.Users", "LivingTown_Id");
            DropColumn("dbo.Users", "BornTown_Id");
            DropTable("dbo.Towns");
        }
    }
}

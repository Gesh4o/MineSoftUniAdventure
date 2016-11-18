namespace _02.CreateUser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInverseProperties : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "Town_Id" });
            DropIndex("dbo.Users", new[] { "Town_Id1" });

            DropIndex("dbo.Users", new[] { "BornTown_Id" });
            DropForeignKey("dbo.Users", "FK_dbo.Users_dbo.Towns_BornTown_Id");

            DropIndex("dbo.Users", new[] { "LivingTown_Id" });
            DropForeignKey("dbo.Users", "FK_dbo.Users_dbo.Towns_LivingTown_Id");

            DropColumn("dbo.Users", "BornTown_Id");
            DropColumn("dbo.Users", "LivingTown_Id");
            RenameColumn(table: "dbo.Users", name: "Town_Id", newName: "BornTown_Id");
            RenameColumn(table: "dbo.Users", name: "Town_Id1", newName: "LivingTown_Id");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Users", name: "LivingTown_Id", newName: "Town_Id1");
            RenameColumn(table: "dbo.Users", name: "BornTown_Id", newName: "Town_Id");
            AddColumn("dbo.Users", "LivingTown_Id", c => c.Int());
            AddColumn("dbo.Users", "BornTown_Id", c => c.Int());
            CreateIndex("dbo.Users", "Town_Id1");
            CreateIndex("dbo.Users", "Town_Id");
        }
    }
}

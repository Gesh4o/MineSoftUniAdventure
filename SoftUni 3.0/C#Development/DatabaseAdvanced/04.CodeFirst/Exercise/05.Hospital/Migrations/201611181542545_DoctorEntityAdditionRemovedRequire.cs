namespace _05.Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorEntityAdditionRemovedRequire : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Specialty = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Visitations", "Doctor_Id", c => c.Int());
            CreateIndex("dbo.Visitations", "Doctor_Id");
            AddForeignKey("dbo.Visitations", "Doctor_Id", "dbo.Doctors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitations", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Visitations", new[] { "Doctor_Id" });
            DropColumn("dbo.Visitations", "Doctor_Id");
            DropTable("dbo.Doctors");
        }
    }
}

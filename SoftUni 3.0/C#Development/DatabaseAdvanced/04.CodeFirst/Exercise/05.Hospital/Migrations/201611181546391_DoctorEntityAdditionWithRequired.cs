namespace _05.Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorEntityAdditionWithRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Visitations", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Visitations", new[] { "Doctor_Id" });
            AlterColumn("dbo.Visitations", "Doctor_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Visitations", "Doctor_Id");
            AddForeignKey("dbo.Visitations", "Doctor_Id", "dbo.Doctors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitations", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Visitations", new[] { "Doctor_Id" });
            AlterColumn("dbo.Visitations", "Doctor_Id", c => c.Int());
            CreateIndex("dbo.Visitations", "Doctor_Id");
            AddForeignKey("dbo.Visitations", "Doctor_Id", "dbo.Doctors", "Id");
        }
    }
}

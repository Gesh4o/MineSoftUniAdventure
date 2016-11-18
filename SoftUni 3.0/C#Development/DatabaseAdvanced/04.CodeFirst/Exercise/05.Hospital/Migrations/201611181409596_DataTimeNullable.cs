namespace _05.Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}

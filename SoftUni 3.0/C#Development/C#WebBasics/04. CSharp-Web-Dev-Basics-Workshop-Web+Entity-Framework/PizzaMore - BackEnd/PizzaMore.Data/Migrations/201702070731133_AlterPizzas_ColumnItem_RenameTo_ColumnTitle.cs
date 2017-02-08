namespace PizzaMore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterPizzas_ColumnItem_RenameTo_ColumnTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pizzas", "Title", c => c.String());
            DropColumn("dbo.Pizzas", "Item");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pizzas", "Item", c => c.String());
            DropColumn("dbo.Pizzas", "Title");
        }
    }
}

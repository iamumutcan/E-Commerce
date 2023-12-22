namespace E_Commerce.Core.Model.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class productfix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.Int(nullable: false));
        }
    }
}

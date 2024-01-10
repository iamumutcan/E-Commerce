namespace E_Commerce.Core.Model.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateUserIsDelte : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsDelete", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Users", "IsDelete");
        }
    }
}

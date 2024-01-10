namespace E_Commerce.Core.Model.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PrivateKey", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Users", "PrivateKey");
        }
    }
}

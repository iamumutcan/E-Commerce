namespace E_Commerce.Core.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAddresses", "Country", c => c.String());
            AddColumn("dbo.UserAddresses", "PostalCode", c => c.String());
            AddColumn("dbo.UserAddresses", "Address2", c => c.String());
            AddColumn("dbo.UserAddresses", "BuildingNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAddresses", "BuildingNumber");
            DropColumn("dbo.UserAddresses", "Address2");
            DropColumn("dbo.UserAddresses", "PostalCode");
            DropColumn("dbo.UserAddresses", "Country");
        }
    }
}

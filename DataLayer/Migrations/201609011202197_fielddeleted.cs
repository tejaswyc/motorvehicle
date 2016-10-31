namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fielddeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OwnerDetails", "VehicleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OwnerDetails", "VehicleId", c => c.Int(nullable: false));
        }
    }
}

namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OwnerVehicleIntermediates",
                c => new
                    {
                        intermediateId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        VehiclesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.intermediateId)
                .ForeignKey("dbo.OwnerDetails", t => t.OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleDetails", t => t.VehiclesId, cascadeDelete: true)
                .Index(t => t.OwnerId)
                .Index(t => t.VehiclesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OwnerVehicleIntermediates", "VehiclesId", "dbo.VehicleDetails");
            DropForeignKey("dbo.OwnerVehicleIntermediates", "OwnerId", "dbo.OwnerDetails");
            DropIndex("dbo.OwnerVehicleIntermediates", new[] { "VehiclesId" });
            DropIndex("dbo.OwnerVehicleIntermediates", new[] { "OwnerId" });
            DropTable("dbo.OwnerVehicleIntermediates");
        }
    }
}

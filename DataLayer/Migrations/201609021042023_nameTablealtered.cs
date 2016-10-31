namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameTablealtered : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleDetails", "VehicleType", "dbo.VehicleTypes");
            DropIndex("dbo.VehicleDetails", new[] { "VehicleType" });
            RenameColumn(table: "dbo.VehicleDetails", name: "VehicleName", newName: "VehicleNameId");
            RenameIndex(table: "dbo.VehicleDetails", name: "IX_VehicleName", newName: "IX_VehicleNameId");
            AddColumn("dbo.VehicleNames", "VehicleType", c => c.String());
            DropColumn("dbo.VehicleDetails", "VehicleType");
            DropTable("dbo.VehicleTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.TypeId);
            
            AddColumn("dbo.VehicleDetails", "VehicleType", c => c.Int(nullable: false));
            DropColumn("dbo.VehicleNames", "VehicleType");
            RenameIndex(table: "dbo.VehicleDetails", name: "IX_VehicleNameId", newName: "IX_VehicleName");
            RenameColumn(table: "dbo.VehicleDetails", name: "VehicleNameId", newName: "VehicleName");
            CreateIndex("dbo.VehicleDetails", "VehicleType");
            AddForeignKey("dbo.VehicleDetails", "VehicleType", "dbo.VehicleTypes", "TypeId", cascadeDelete: true);
        }
    }
}

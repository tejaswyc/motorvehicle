namespace DataLayer
{
    using EntityModels;
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Linq;

    public class VehicleRegistrationContext : DbContext
    {
        // Your context has been configured to use a 'VehicleRegistration' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataLayer.VehicleRegistration' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'VehicleRegistration' 
        // connection string in the application configuration file.


        public VehicleRegistrationContext()
            : base("name=VehicleRegistration")
        {

        }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<VehicleDetail> VehicleDetails { get; set; }
        public DbSet<OwnerDetail> OwnerDetails { get; set; }
        public DbSet<Country> Countrys { get; set; }
        
        public DbSet<VehicleName> VehicleNames { get; set; }
        public DbSet<OwnerVehicleIntermediate> OwnerVehicleIntermediates { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<VehicleDetail>().MapToStoredProcedures();
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<OwnerDetail>().MapToStoredProcedures();
        //    base.OnModelCreating(modelBuilder);
        //}
        //public virtual void VehicleDetail_Insert(string VehicleNumber, string VehicleName, string VehicleType, string Colour, string ChasisNumber, string Date, string IsActive)
        //{
        //    var VehicleNumberParameter = VehicleNumber != null ?
        //        new ObjectParameter("VehicleNumber", VehicleNumber) :
        //        new ObjectParameter("VehicleNumber", typeof(string));

        //    var VehicleNameParameter = VehicleName!= null ?
        //    new ObjectParameter("VehicleName", VehicleName):
        //    new ObjectParameter("VehicleName", typeof(string));

        //    var VehicleTypeParameter = VehicleType!= null ?
        //    new ObjectParameter("VehicleType", VehicleType):
        //    new ObjectParameter("VehicleType", typeof(string));

        //    var ColourParameter = Colour != null ?
        //        new ObjectParameter("Colour", Colour) :
        //        new ObjectParameter("Colour", typeof(string));

        //    var ChasisNumberParameter = ChasisNumber != null ?
        //        new ObjectParameter("ChasisNumber", ChasisNumber) :
        //        new ObjectParameter("ChasisNumber", typeof(string));

        //    var DateParameter = Date != null ?
        //        new ObjectParameter("Date", Date) :
        //        new ObjectParameter("Date", typeof(string));
        //    var IsActiveParameter = IsActive!=  null?
        //    new ObjectParameter("IsActive", IsActive):
        //    new ObjectParameter("IsActive", typeof(string));

        //   // return ((Migrations.vehicledetailSP).ExecuteFunction("VehicleDetail_Insert",VehicleNumberParameter, VehicleNameParameter, VehicleTypeParameter, ColourParameter, ChasisNumberParameter, DateParameter, IsActiveParameter));
        //}
    }
}

      

    // Add a DbSet for each entity type that you want to include in your model. For more information 
    // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

    // public virtual DbSet<MyEntity> MyEntities { get; set; }


    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

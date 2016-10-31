namespace Model
{
    public class CompleteDetailsOfVehicle
    {
        public int VehicleId { get; set; }

        public string VehicleNumber { get; set; }
      
        public int VehicleNameId { get; set; }
        
        public string VehicleName { get; set; }
      
        public int VehicleTypeId { get; set; }
       
        public string VehicleType { get; set; }
        public string Colour { get; set; }
        public string ChasisNumber { get; set; }
       
        public string Date { get; set; }
        
        public bool IsActive { get; set; }
       
        public string OwnerName { get; set; }
        public string Address { get; set; }
       

        public int CountryId { get; set; }
        
        public string Country { get; set; }
    }
}

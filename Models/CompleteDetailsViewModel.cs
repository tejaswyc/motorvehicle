using System.Collections.Generic;
using System.Web.Mvc;

namespace Model
{
    public class CompleteDetailsViewModel
    {
        public string VehicleNumber { get; set; }
        public int VehicleNameId { get; set; }
        public string VehicleName { get; set; }
        public int VehicleTypeId { get; set; }
        public string Colour { get; set; }
        public string ChasisNumber { get; set; }
        public string CountryName { get; set; }
        public string Date { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }

        public int CountryId { get; set; }
        public List<SelectListItem> CountryList { get; set; }
        public List<SelectListItem> OwnerList { get; set; }
        public List<SelectListItem> NameList { get; set; }
    }
}

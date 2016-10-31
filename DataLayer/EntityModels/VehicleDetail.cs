using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.EntityModels
{
    public class VehicleDetail
    {
        public VehicleDetail()
        {
            IsActive = true;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int VehicleId { get; set; }
        [Required]
        public string VehicleNumber { get; set; }
        [Required]
        public int VehicleNameId { get; set; }
        [ForeignKey("VehicleNameId")]
        public  VehicleName NameId { get; set; }
        
        public string Colour { get; set; }
        public string ChasisNumber { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        
        public bool IsActive { get; set; }

    }
}

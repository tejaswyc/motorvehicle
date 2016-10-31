using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EntityModels
{
    public class OwnerVehicleIntermediate
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intermediateId { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public OwnerDetail Id { get; set; }
        [Required]
        public int VehiclesId { get; set; }
        [ForeignKey("VehiclesId")]
        public VehicleDetail VehicleId{ get; set; }
    }
}

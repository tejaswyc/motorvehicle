using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EntityModels
{
    public class VehicleName
    {
        [Key]
        public int NameId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<VehicleDetail> VehicleDetails { get; set; }
        public string VehicleType { get; set; }

    }
}

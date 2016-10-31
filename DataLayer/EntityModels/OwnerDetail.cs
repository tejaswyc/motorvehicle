using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EntityModels
{
    public class OwnerDetail
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
 
        [Required]
        public string OwnerName { get; set; }
        public string Address { get; set; }
        [Required]
        
        public int Country { get; set; }
        [ForeignKey("Country")]
        public Country CountryId { get; set; }
    }
}

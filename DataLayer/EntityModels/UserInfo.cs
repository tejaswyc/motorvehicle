using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EntityModels
{
    public class UserInfo
    {
        


            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public int UserId { get; set; }
            [Required]
            public string Firstname { get; set; }
            [Required]
            public string Lastname { get; set; }
            [Required(ErrorMessage = "Please enter a valid username.")]
            public string Username { get; set; }
            [Required(ErrorMessage = "Please enter a valid password.")]
            public string Password { get; set; }
        }
    }


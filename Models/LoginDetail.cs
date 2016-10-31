using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class LoginDetail
    {
            [Required(ErrorMessage = "Username is mandatory")]
            public string Username { get; set; }
            [Required(ErrorMessage = "Password is mandatory")]
            public string Password { get; set; }
        }
    }




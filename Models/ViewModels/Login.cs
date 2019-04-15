using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models
{
    public class Login
    {  
        [Required]
        [EmailAddress]
        public string logEmail { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        public string logPassword { get; set; }
    }

}
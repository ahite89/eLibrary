using System.ComponentModel.DataAnnotations;

namespace LibraryBackEnd.Models
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,16}$", ErrorMessage = "Password must match requirements")]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Role { get; set; }
    }
}

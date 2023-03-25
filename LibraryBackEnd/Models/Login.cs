using System.ComponentModel.DataAnnotations;

namespace LibraryBackEnd.Models
{
    public class Login
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

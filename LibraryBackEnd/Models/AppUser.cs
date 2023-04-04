using Microsoft.AspNetCore.Identity;

namespace LibraryBackEnd.Models
{
    public class AppUser: IdentityUser
    {
        public string Role { get; set; }
        public DateTime DateAdded { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using LibraryBackEnd.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibraryBackEnd.Data
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookCover> BookCovers { get; set; }
    }
}

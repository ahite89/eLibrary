using System.ComponentModel.DataAnnotations;

namespace LibraryBackEnd.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Year { get; set; }
        public bool CheckedOut { get; set; } = false;
        public Guid? CheckedOutBy { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid AddedBy { get; set; }
        public BookCover? BookCover { get; set; }
        public string? BookCoverUrl { get; set; }
    }
}

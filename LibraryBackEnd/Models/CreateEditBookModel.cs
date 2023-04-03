using System.ComponentModel.DataAnnotations;

namespace LibraryBackEnd.Models
{
    public class CreateEditBookModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Year { get; set; }

        public Guid? Id { get; set; }

        public IFormFile? BookCoverFile { get; set; }

        public string? Username { get; set; }
    }
}

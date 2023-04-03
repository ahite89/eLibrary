using LibraryBackEnd.Models;

namespace LibraryBackEnd.Interfaces
{
    public interface ILibraryService
    {
        // Book Services
        Task<List<Book>> GetAllBooksAsync();
        Task<Result<Book>> AddBookAsync(Book book);
        Task<Book> EditBookAsync(CreateEditBookModel bookData);
        Task<Book> CheckInOutBookAsync(Book book, bool checkingOut, string userId = "");
        Task<(bool, string)> DeleteBookAsync(Book book);
    }
}

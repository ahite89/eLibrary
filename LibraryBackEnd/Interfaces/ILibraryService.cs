using LibraryBackEnd.Models;

namespace LibraryBackEnd.Interfaces
{
    public interface ILibraryService
    {
        Task<Result<List<Book>>> GetAllBooksAsync();
        Task<Result<Book>> AddBookAsync(Book book);
        Task<Result<Book>> EditBookAsync(CreateEditBookModel bookData);
        Task<Result<Book>> CheckInOutBookAsync(Book book, bool checkingOut, string userId = "");
        Task<Result<Book>> DeleteBookAsync(Book book);
    }
}

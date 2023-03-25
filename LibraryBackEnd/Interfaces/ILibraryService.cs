using LibraryBackEnd.Models;

namespace LibraryBackEnd.Interfaces
{
    public interface ILibraryService
    {
        // Book Services
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookAsync(Guid id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> EditBookAsync(Book book);
        Task<(bool, string)> DeleteBookAsync(Book book);
    }
}

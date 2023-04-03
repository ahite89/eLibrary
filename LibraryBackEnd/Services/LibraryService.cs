using Microsoft.EntityFrameworkCore;
using LibraryBackEnd.Data;
using LibraryBackEnd.Models;
using Microsoft.AspNetCore.Identity;
using LibraryBackEnd.Interfaces;

namespace LibraryBackEnd.Services
{
    public class LibraryService: ILibraryService
    {
        private readonly AppDbContext _dbContext;

        public LibraryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            try
            {
                return await _dbContext.Books.ToListAsync();
            }
            catch
            {
                return new List<Book>();
            }
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            try
            {
                await _dbContext.Books.AddAsync(book);
                await _dbContext.SaveChangesAsync();
                return await _dbContext.Books.FindAsync(book.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Book> EditBookAsync(CreateEditBookModel bookData)
        {
            try
            {
                var dbBook = await _dbContext.Books.FindAsync(bookData.Id);

                if (dbBook != null)
                {
                    dbBook.Title = bookData.Title;
                    dbBook.Author = bookData.Author;
                    dbBook.Description = bookData.Description;
                    dbBook.Year = bookData.Year;
                    _dbContext.Entry(dbBook).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();

                    return dbBook;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Book> CheckInOutBookAsync(Book book, bool checkingOut, string userId)
        {
            try
            {
                var dbBook = await _dbContext.Books.FindAsync(book.Id);

                if (dbBook != null)
                {
                    if (checkingOut)
                    {
                        dbBook.CheckedOutBy = Guid.Parse(userId);
                        dbBook.CheckedOut = true;
                    }
                    else
                    {
                        dbBook.CheckedOutBy = null;
                        dbBook.CheckedOut = false;
                    }

                    _dbContext.Entry(dbBook).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();

                    return dbBook;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(bool, string)> DeleteBookAsync(Book book)
        {
            try
            {
                var dbBook = await _dbContext.Books.FindAsync(book.Id);
                
                if (dbBook == null)
                {
                    return (false, "This book could not be found");
                }

                _dbContext.Books.Remove(dbBook);
                await _dbContext.SaveChangesAsync();

                return (true, "This book has been removed from the library");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

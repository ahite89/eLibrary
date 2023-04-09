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

        // ADD LOGGING
        public async Task<Result<List<Book>>> GetAllBooksAsync()
        {
            try
            {
                var books = await _dbContext.Books.ToListAsync();
                return Result<List<Book>>.Success(books);
            }
            catch (Exception ex)
            {
                return Result<List<Book>>.Failure(ex.Message);
            }
        }

        public async Task<Result<Book>> AddBookAsync(Book book)
        {
            try
            {
                await _dbContext.Books.AddAsync(book);
                await _dbContext.SaveChangesAsync();
                var dbBook = await _dbContext.Books.FindAsync(book.Id);

                return Result<Book>.Success(dbBook);
            }
            catch (Exception ex)
            {
                return Result<Book>.Failure(ex.Message);
            }
        }

        public async Task<Result<Book>> EditBookAsync(CreateEditBookModel bookData)
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
                }

                return Result<Book>.Success(dbBook);
            }
            catch (Exception ex)
            {
                return Result<Book>.Failure(ex.Message);
            }
        }

        public async Task<Result<Book>> CheckInOutBookAsync(Book book, bool checkingOut, string userId)
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
                }

                return Result<Book>.Success(dbBook);
            }
            catch (Exception ex)
            {
                return Result<Book>.Failure(ex.Message);
            }
        }

        public async Task<Result<Book>> DeleteBookAsync(Book book)
        {
            try
            {
                var dbBook = await _dbContext.Books.FindAsync(book.Id);

                if (dbBook != null)
                {
                    _dbContext.Books.Remove(dbBook);
                    await _dbContext.SaveChangesAsync();
                }

                return Result<Book>.Success(dbBook);
            }
            catch (Exception ex)
            {
                return Result<Book>.Failure(ex.Message);
            }
        }
    }
}

using LibraryBackEnd.Interfaces;
using LibraryBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBackEnd.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        private readonly IBookCoverService _bookCoverService;
        private readonly UserManager<AppUser> _userManager;

        public LibraryController(ILibraryService libraryService, UserManager<AppUser> userManager, IBookCoverService bookCoverService)
        {
            _libraryService = libraryService;
            _userManager = userManager;
            _bookCoverService = bookCoverService;
        }

        [HttpGet]
        [Authorize(Roles = "user, librarian")]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            List<Book> books = await _libraryService.GetAllBooksAsync();

            if (books == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No books found");
            }

            return books;
        }

        [HttpPost("create")]
        [Authorize(Roles = "librarian")]
        public async Task<ActionResult<Book>> AddBook([FromForm] CreateEditBookModel bookData)
        {
            var user = await _userManager.FindByNameAsync(bookData.Username);

            if (user == null) return Unauthorized();

            var bookCover = new Photo();

            if (bookData.BookCoverFile != null)
            {
                bookCover = await _bookCoverService.AddBookCoverEntity(bookData.BookCoverFile);
            }

            var newBook = new Book
            {
                Title = bookData.Title,
                Author = bookData.Author,
                Description = bookData.Description,
                Year = bookData.Year,
                AddedBy = Guid.Parse(user.Id),
                DateAdded = DateTime.Now,
                BookCover = bookCover ?? null,
                BookCoverUrl = bookCover == null ? null : bookCover.Url
            };

            Book dbBook = await _libraryService.AddBookAsync(newBook);

            if (dbBook == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{newBook.Title} could not be added");
            }

            return dbBook;
        }

        [HttpPost("edit")]
        [Authorize(Roles = "librarian")]
        public async Task<ActionResult<Book>> EditBook([FromForm] CreateEditBookModel bookData)
        {
            // DEAL WITH CLOUDINARY STUFF

            // take in createeditbook model
            // use bookcover file to see if image exists in cloudinary
            // if so, don't include it
            // otherwise, use book cover service

            var bookCover = new Photo();

            if (bookData.BookCoverFile != null)
            {
                bookCover = _bookCoverService.GetBookCoverFromCloudinary(bookData.BookCoverFile);
            }

            Book dbBook = await _libraryService.EditBookAsync(bookData);

            if (dbBook == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{bookData.Title} could not be edited");
            }

            return dbBook;
        }

        [HttpPost("checkout")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<Book>> CheckoutBook(Book book)
        {
            // CREATE CHECKIN/OUT MODEL TO DEAL WITH USERNAME

            string username = "zhite89";
            var user = await _userManager.FindByNameAsync(username);

            if (user == null) return Unauthorized();

            Book dbBook = await _libraryService.CheckInOutBookAsync(book, true, user.Id);

            if (dbBook == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{book.Title} could not be checked out");
            }

            return dbBook;
        }

        [HttpPost("checkin")]
        [Authorize(Roles = "librarian")]
        public async Task<ActionResult<Book>> CheckinBook(Book book)
        {
            Book dbBook = await _libraryService.CheckInOutBookAsync(book, false);

            if (dbBook == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{book.Title} could not be checked in");
            }

            return dbBook;
        }

        [HttpPost("delete")]
        [Authorize(Roles = "librarian")]
        public async Task<ActionResult<Book>> DeleteBook(Book book)
        {
            (bool status, string message) = await _libraryService.DeleteBookAsync(book);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return book;
        }
    }
}

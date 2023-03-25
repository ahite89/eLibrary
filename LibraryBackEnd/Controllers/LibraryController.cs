using Microsoft.AspNetCore.Mvc;
using LibraryBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using LibraryBackEnd.Interfaces;

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
        //[Authorize(Roles = "User, Librarian")]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            List<Book> books = await _libraryService.GetAllBooksAsync();

            if (books == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No books found");
            }

            return books;
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "User, Librarian")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            Book book = await _libraryService.GetBookAsync(id);

            if (book == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No book found for id: {id}");
            }

            return book;
        }

        [HttpPost("create")]
        //[Authorize(Roles = "Librarian")]
        public async Task<ActionResult<Book>> AddBook([FromForm] CreateBookModel formData)
        {
            string email = "ahite89@gmail.com";
            var user = await _userManager.FindByEmailAsync(email);

            var bookCover = await _bookCoverService.AddBookCoverEntity(formData.BookCoverFile);

            var newBook = new Book
            {
                Title = formData.Title,
                Author = formData.Author,
                Description = formData.Description,
                Year = formData.Year,
                AddedBy = Guid.Parse(user.Id),
                DateAdded = DateTime.Now,
                BookCover = bookCover,
                BookCoverUrl = bookCover.Url
            };

            Book dbBook = await _libraryService.AddBookAsync(newBook);

            if (dbBook == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{newBook.Title} could not be added");
            }

            return dbBook;
        }

        [HttpPost("edit")]
        //[Authorize(Roles = "Librarian")]
        public async Task<ActionResult<Book>> EditBook(Book book)
        {
            Book dbBook = await _libraryService.EditBookAsync(book);

            if (dbBook == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{book.Title} could not be edited");
            }

            return book;
        }

        [HttpPost("checkout")]
        //[Authorize(Roles = "User")]
        public async Task<ActionResult<Book>> CheckoutBook(Book book)
        {
            string email = "zhite89@gmail.com";
            var user = await _userManager.FindByEmailAsync(email);

            book.CheckedOutBy = Guid.Parse(user.Id);
            book.CheckedOut = true;

            Book dbBook = await _libraryService.EditBookAsync(book);

            if (dbBook == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{book.Title} could not be checked out");
            }

            return book;
        }

        [HttpPost("checkin")]
        //[Authorize(Roles = "Librarian")]
        public async Task<ActionResult<Book>> CheckinBook(Book book)
        {
            book.CheckedOutBy = null;
            book.CheckedOut = false;

            Book dbBook = await _libraryService.EditBookAsync(book);

            if (dbBook == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{book.Title} could not be checked in");
            }

            return book;
        }

        [HttpPost("delete")]
        //[Authorize(Roles = "Librarian")]
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

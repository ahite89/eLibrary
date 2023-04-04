using LibraryBackEnd.Interfaces;
using LibraryBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : BaseApiController
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
        public async Task<IActionResult> GetAllBooks()
        {
            return HandleResult(await _libraryService.GetAllBooksAsync());
        }

        [HttpPost("create")]
        [Authorize(Roles = "librarian")]
        public async Task<IActionResult> AddBook([FromForm] CreateEditBookModel bookData)
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

            return HandleResult(await _libraryService.AddBookAsync(newBook));
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

            return HandleResult(await _libraryService.EditBookAsync(bookData));
        }

        [HttpPost("checkout")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<Book>> CheckoutBook(Book book)
        {
            // CREATE CHECKIN/OUT MODEL TO DEAL WITH USERNAME

            string username = "zhite89";
            var user = await _userManager.FindByNameAsync(username);

            if (user == null) return Unauthorized();

            return HandleResult(await _libraryService.CheckInOutBookAsync(book, true, user.Id));            
        }

        [HttpPost("checkin")]
        [Authorize(Roles = "librarian")]
        public async Task<ActionResult<Book>> CheckinBook(Book book)
        {
            return HandleResult(await _libraryService.CheckInOutBookAsync(book, false));
        }

        [HttpPost("delete")]
        [Authorize(Roles = "librarian")]
        public async Task<ActionResult<Book>> DeleteBook(Book book)
        {
            return HandleResult(await _libraryService.DeleteBookAsync(book));
        }
    }
}

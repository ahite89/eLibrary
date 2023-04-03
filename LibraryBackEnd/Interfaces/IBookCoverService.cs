using LibraryBackEnd.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LibraryBackEnd.Interfaces
{
    public interface IBookCoverService
    {
        Photo GetBookCoverFromCloudinary(IFormFile file);
        Task<BookCoverUploadResult> AddBookCoverToCloudinary(IFormFile file);
        Task<Photo> AddBookCoverEntity(IFormFile file);
    }
}

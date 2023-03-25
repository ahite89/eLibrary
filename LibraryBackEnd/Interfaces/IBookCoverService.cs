using LibraryBackEnd.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LibraryBackEnd.Interfaces
{
    public interface IBookCoverService
    {
        Task<BookCoverUploadResult> AddBookCoverToCloudinary(IFormFile file);
        Task<BookCover> AddBookCoverEntity(IFormFile file);
    }
}

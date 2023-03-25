using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using LibraryBackEnd.Data;
using LibraryBackEnd.Interfaces;
using LibraryBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LibraryBackEnd.Services
{
    public class BookCoverService : IBookCoverService
    {
        private readonly Cloudinary _cloudinary;
        private readonly AppDbContext _dbContext;
        public BookCoverService(IOptions<CloudinarySettings> config, AppDbContext dbContext) 
        {
            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(account);
            _dbContext = dbContext;
        }

        public async Task<BookCover> AddBookCoverEntity(IFormFile file)
        {
            var bookCoverUploadResult = await AddBookCoverToCloudinary(file);

            var bookCover = new BookCover
            {
                Url = bookCoverUploadResult.Url,
                Id = bookCoverUploadResult.PublicId
            };

            _dbContext.BookCovers.Add(bookCover);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (result)
            {
                return bookCover;
            }

            return null;
        }

        public async Task<BookCoverUploadResult> AddBookCoverToCloudinary(IFormFile file)
        {
            if (file.Length > 0)
            {
                await using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(300).Width(150)
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                {
                    throw new Exception(uploadResult.Error.Message);
                }

                return new BookCoverUploadResult
                {
                    PublicId = uploadResult.PublicId,
                    Url = uploadResult.SecureUrl.ToString()
                };
            }

            return null;
        }
    }
}

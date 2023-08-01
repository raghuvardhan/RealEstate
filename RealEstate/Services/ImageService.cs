using System;
using RealEstate.Models;
using UserManagement;

namespace RealEstate.Services
{
    public interface IImageService
    {
        Task<Image> UploadImage(IFormFile file, int listingId);
        Task<Image> GetImage(int imageId);
        Task DeleteImage(int imageId);
    }

    public class ImageService : IImageService
    {
        private readonly MyDbContext _context;

        public ImageService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Image> UploadImage(IFormFile file, int listingId)
        {
            // Upload the image file to Azure Blob Storage (or another service) and get the image URL
            string imageUrl = UploadToBlobStorage(file);

            // Create a new Image record
            Image image = new Image
            {
                ListingID = listingId,
                ImageURL = imageUrl
            };

            // Save the Image record to the database
            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return image;
        }

        public async Task<Image> GetImage(int imageId)
        {
            return await _context.Images.FindAsync(imageId);
        }

        public async Task DeleteImage(int imageId)
        {
            var image = await _context.Images.FindAsync(imageId);
            if (image == null)
            {
                // Handle not found
                return;
            }

            // Delete the image file from Azure Blob Storage (or another service)
            DeleteFromBlobStorage(image.ImageURL);

            // Delete the Image record from the database
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }

        private string UploadToBlobStorage(IFormFile file)
        {
            return "";
      
            // Implement this method to upload the file to Azure Blob Storage and return the image URL
        }

        private void DeleteFromBlobStorage(string imageUrl)
        {
            // Implement this method to delete the image file from Azure Blob Storage
        }
    }

}


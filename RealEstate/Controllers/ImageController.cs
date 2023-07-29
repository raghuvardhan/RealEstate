using System;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Services;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<ActionResult<Image>> UploadImage([FromForm] IFormFile file, [FromQuery] int listingId)
        {
            return await _imageService.UploadImage(file, listingId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(int id)
        {
            return await _imageService.GetImage(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            await _imageService.DeleteImage(id);
            return NoContent();
        }
    }

}


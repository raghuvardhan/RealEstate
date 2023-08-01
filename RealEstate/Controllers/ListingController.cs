
using System;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Services;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly IListingService _listingService;

        public ListingController(IListingService listingService)
        {
            _listingService = listingService;
        }

        [HttpPost]
        public async Task<ActionResult<Listing>> AddListing(Listing listing)
        {
            return await _listingService.AddListing(listing);
        }

        [HttpGet]
        public async Task<ActionResult<List<Listing>>> GetListings()
        {
            return await _listingService.GetListings();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Listing>> GetListing(int id)
        {
            return await _listingService.GetListing(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Listing>> UpdateListing(int id, Listing listing)
        {
            if (id != listing.ListingID)
            {
                return BadRequest();
            }

            return await _listingService.UpdateListing(listing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListing(int id)
        {
            await _listingService.DeleteListing(id);
            return NoContent();
        }
    }

}


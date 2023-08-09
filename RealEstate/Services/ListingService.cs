using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RealEstate.Models;
using UserManagement;
using UserManagement.Models;

namespace RealEstate.Services
{
    public interface IListingService
    {
        Task<Listing> AddListing(Listing listing);
        Task<Listing> UpdateListing(Listing listing);
        Task<Listing> GetListing(int listingId);
        Task DeleteListing(int listingId);
        Task<List<Listing>> GetListings();
    }

    public class ListingService : IListingService
    {
        private readonly MyDbContext _context;
        private readonly IGeocodingService _geocodingService;

        public ListingService(MyDbContext context, IGeocodingService geocodingService)
        {
            _context = context;
            _geocodingService = geocodingService;
        }

        public async Task<Listing> AddListing(Listing listing)
        {
            // Use the Geocoding Service to get the geolocation details of the listing
            GeocodeResponse geocodeResponse = await _geocodingService.Geocode(listing.Location);

            // Add the geolocation details to the listing
            if (geocodeResponse != null && geocodeResponse.results.Count > 0)
            {
                listing.Lat = geocodeResponse.results[0].geometry.location.lat;
                listing.Lng = geocodeResponse.results[0].geometry.location.lng;
            }

            _context.Listings.Add(listing);
            await _context.SaveChangesAsync();
            return listing;
        }

        public async Task<Listing> UpdateListing(Listing listing)
        {
            _context.Entry(listing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return listing;
        }

        public async Task<Listing> GetListing(int listingId)
        {
            return await _context.Listings.FindAsync(listingId);
        }

        public async Task<List<Listing>> GetListings()
        {
            List<Listing> listings = new List<Listing>
            {
                new Listing()
                {
                    Id = 1,

                    UserID = 1,

                    User = new User(),

                    Title = "purab manor",

                    Description = "resale",

                    Price = 8000000,

                    Location = "bangalore",

                    NumberOfBedrooms = 3,

                    NumberOfBathrooms = 3,

                    PropertyType = "new",

                    ListedAt = new DateTime(),

                    Lat = 99.0,

                    Lng = 99.0
                },
                 new Listing()
                {
                    Id = 2,

                    UserID = 2,

                    User = new User(),

                    Title = "Sky Villas",

                    Description = "resale",

                    Price = 8000000,

                    Location = "bangalore",

                    NumberOfBedrooms = 3,

                    NumberOfBathrooms = 3,

                    PropertyType = "new",

                    ListedAt = new DateTime(),

                    Lat = 99.0,

                    Lng = 99.0
                },
                  new Listing()
                {
                    Id = 3,

                    UserID = 3,

                    User = new User(),

                    Title = "Nature Villas",

                    Description = "resale",

                    Price = 8000000,

                    Location = "Mumbai",

                    NumberOfBedrooms = 3,

                    NumberOfBathrooms = 3,

                    PropertyType = "new",

                    ListedAt = new DateTime(),

                    Lat = 99.0,

                    Lng = 99.0
                },
                   new Listing()
                {
                    Id = 4,

                    UserID = 4,

                    User = new User(),

                    Title = "Water Villas",

                    Description = "resale",

                    Price = 8000000,

                    Location = "bangalore",

                    NumberOfBedrooms = 3,

                    NumberOfBathrooms = 3,

                    PropertyType = "new",

                    ListedAt = new DateTime(),

                    Lat = 99.0,

                    Lng = 99.0
                },
                    new Listing()
                {
                    Id = 5,

                    UserID = 5,

                    User = new User(),

                    Title = "Forest View Villa",

                    Description = "resale",

                    Price = 8000000,

                    Location = "Hyderabad",

                    NumberOfBedrooms = 3,

                    NumberOfBathrooms = 3,

                    PropertyType = "new",

                    ListedAt = new DateTime(),

                    Lat = 99.0,

                    Lng = 99.0
                },
                     new Listing()
                {
                    Id = 6,

                    UserID = 6,

                    User = new User(),

                    Title = "purab high manor",

                    Description = "resale",

                    Price = 8000000,

                    Location = "Kerala",

                    NumberOfBedrooms = 3,

                    NumberOfBathrooms = 3,

                    PropertyType = "new",

                    ListedAt = new DateTime(),

                    Lat = 99.0,

                    Lng = 99.0
                },

            };
            return await Task.FromResult(listings);
            //return await _context.Listings.ToListAsync();
        }

        public async Task DeleteListing(int listingId)
        {
            var listing = await _context.Listings.FindAsync(listingId);
            if (listing == null)
            {
                // Handle not found
                return;
            }

            _context.Listings.Remove(listing);
            await _context.SaveChangesAsync();
        }
    }

}


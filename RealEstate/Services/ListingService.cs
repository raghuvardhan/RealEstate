﻿using System;
using RealEstate.Models;

namespace RealEstate.Services
{
    public interface IListingService
    {
        Task<Listing> AddListing(Listing listing);
        Task<Listing> UpdateListing(Listing listing);
        Task<Listing> GetListing(int listingId);
        Task DeleteListing(int listingId);
    }

    public class ListingService : IListingService
    {
        private readonly MyDbContext _context;
        private readonly IGeocodingService _geocodingService;

        public ListingService(MyDbContext context, GeocodingService geocodingService)
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

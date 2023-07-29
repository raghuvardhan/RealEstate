using System;
using RealEstate.Models;

namespace RealEstate.Services
{
    public interface ISearchFilterService
    {
        Task<List<Listing>> SearchFilter(SearchFilterDto searchFilter);
    }

    public class SearchFilterService : ISearchFilterService
    {
        private readonly MyDbContext _context;

        public SearchFilterService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Listing>> SearchFilter(SearchFilterDto searchFilter)
        {
            // Start with a query that selects all listings
            IQueryable<Listing> query = _context.Listings;

            // Add conditions to the query based on the search filter parameters
            if (!string.IsNullOrEmpty(searchFilter.Keyword))
            {
                query = query.Where(l => l.Title.Contains(searchFilter.Keyword) || l.Description.Contains(searchFilter.Keyword));
            }
            if (searchFilter.MinPrice.HasValue)
            {
                query = query.Where(l => l.Price >= searchFilter.MinPrice.Value);
            }
            if (searchFilter.MaxPrice.HasValue)
            {
                query = query.Where(l => l.Price <= searchFilter.MaxPrice.Value);
            }
            if (!string.IsNullOrEmpty(searchFilter.Location))
            {
                query = query.Where(l => l.Location == searchFilter.Location);
            }
            if (searchFilter.MinBedrooms.HasValue)
            {
                query = query.Where(l => l.NumberOfBedrooms >= searchFilter.MinBedrooms.Value);
            }
            if (searchFilter.MinBathrooms.HasValue)
            {
                query = query.Where(l => l.NumberOfBathrooms >= searchFilter.MinBathrooms.Value);
            }
            if (!string.IsNullOrEmpty(searchFilter.PropertyType))
            {
                query = query.Where(l => l.PropertyType == searchFilter.PropertyType);
            }

            // Execute the query and return the results
            return await query.ToListAsync();
        }
    }

}


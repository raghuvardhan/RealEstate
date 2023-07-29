using System;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Services;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchFilterController : ControllerBase
    {
        private readonly ISearchFilterService _searchFilterService;

        public SearchFilterController(ISearchFilterService searchFilterService)
        {
            _searchFilterService = searchFilterService;
        }

        [HttpPost]
        public async Task<ActionResult<List<Listing>>> SearchFilter(SearchFilterDto searchFilter)
        {
            return await _searchFilterService.SearchFilter(searchFilter);
        }
    }

}


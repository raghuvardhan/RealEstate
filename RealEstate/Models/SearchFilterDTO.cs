using System;
namespace RealEstate.Models
{
    public class SearchFilterDto
    {
        public string Keyword { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string Location { get; set; }
        public int? MinBedrooms { get; set; }
        public int? MinBathrooms { get; set; }
        public string PropertyType { get; set; }
    }

}


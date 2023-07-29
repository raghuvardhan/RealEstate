using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }

        [ForeignKey("Listing")]
        public int ListingID { get; set; }

        public Listing Listing { get; set; }

        [Required]
        public string ImageURL { get; set; }
    }

}


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserManagement.Models;

namespace RealEstate.Models
{
    public class Listing
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public User User { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public int NumberOfBedrooms { get; set; }

        public int NumberOfBathrooms { get; set; }

        public string PropertyType { get; set; }

        public DateTime ListedAt { get; set; }

        public double? Lat { get; set; }

        public double? Lng { get; set; }
    }

}


using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }
    }

}


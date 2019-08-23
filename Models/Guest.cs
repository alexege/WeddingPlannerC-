using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using WeddingPlanner.Models;

namespace WeddingPlanner
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }

        [Required(ErrorMessage="First Name is required.")]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Last Name is required.")]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be as least 8 characters long.")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string Confirm_Password { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }

        public List<RSVP> RSVPs { get; set; }
    }
}
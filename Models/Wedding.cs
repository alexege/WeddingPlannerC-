using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using WeddingPlanner.Models;

namespace WeddingPlanner
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        [Required(ErrorMessage="Bride name required.")]
        public string Bride { get; set; }
        
        [Required(ErrorMessage="Groom name required.")]
        public string Groom { get; set; }
        [Required(ErrorMessage="Date required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage="Address cannot be blank.")]
        public string Address { get; set; }

        public List<RSVP> RSVPs { get; set; }

        public Guest Creator { get; set; }
    }
}

    public class DateCheckAttribute : ValidationAttribute{
    protected override ValidationResult IsValid(object date, ValidationContext validationContext){
        DateTime day = Convert.ToDateTime(date);
        DateTime now  =  DateTime.Now;
        if(day<now){
            return new ValidationResult("Weddings cannot be in the past.");
        }else{
            return ValidationResult.Success;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class RSVP
    {
        [Key]
        public int RSVPId{get;set;}
        public int WeddingId{get;set;}
        public int GuestId{get;set;}
        public bool RSVPed{get;set;}

        public RSVP(int WeddingId, int GuestId)
        {
            this.WeddingId = WeddingId;
            this.GuestId = GuestId;
            this.RSVPed = true;
        }
        
        //Navigation Properties

        public Wedding Wedding{get;set;}
        public Guest Guest{get;set;}
    }
}
﻿using System.ComponentModel.DataAnnotations;

namespace CabInventoryManagement.Models
{
    public class RouteDetails
    {
        [Key]
        public int id { get; set; }
        public string Onboarding { get; set; }
        public string Destination { get; set; }
        public string TimeSlot { get; set; }
        public int NoOfAvailableCars { get; set; }


    }
}

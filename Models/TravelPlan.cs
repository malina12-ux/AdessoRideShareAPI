using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace AdessoRideShareAPI.Models
{
    public class TravelPlan
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Seats { get; set; }
        public bool isActive { get; set; }
        public ICollection<Passengers> Passengers { get; set; }
      = new List<Passengers>();

    }
}

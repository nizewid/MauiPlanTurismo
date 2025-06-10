using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPlanTurismo.Models
{
    public class TouristDestination
    {
        public int Id { get; set; }
        public string? HotelName { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public bool HasBeach { get; set; }
        public bool HasPool { get; set; }
        public bool IncludesBreakfast { get; set; }
        public bool IsHotel { get; set; }
        public int Stars { get; set; }
        public string? Image { get; set; }
        public string? Price { get; set; }
    }
}


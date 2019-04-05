using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        public int AmenitiesID { get; set; }
        public int RoomsID { get; set; }

        public Amenities Amenities { get; set; }
        public Rooms Rooms { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Rooms
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public RoomLayout Layout { get; set; }

        ICollection<HotelRooms> HotelRooms { get; set; }

        ICollection<RoomAmenities> RoomAmenities { get; set; }

        public enum RoomLayout
        {
            Studio,
            OneBedroom,
            TwoBedroom,
            PentHouse,
            QueenSuite,
            KingSuite,
        }

    }


}

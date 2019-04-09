using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRooms>().HasKey(ce => new { ce.HotelsID, ce.RoomsID });
            modelBuilder.Entity<RoomAmenities>().HasKey(ce => new { ce.RoomsID, ce.AmenitiesID });

            modelBuilder.Entity<Hotels>().HasData(
                new Hotels
                {
                    ID = 1,
                    Name = "Hotel Cartmon",
                    StreetAddress = "123 E 8th St",
                    City = "Seattle",
                    State = "Washington",
                    Phone = "206-956-5555",
                },
                new Hotels
                {
                    ID = 2,
                    Name = "Hotel Code Fellows",
                    StreetAddress = "123 E 8th St",
                    City = "Seattle",
                    State = "Washington",
                    Phone = "206-654-5555",
                },
                 new Hotels
                {
                    ID = 3,
                    Name = "Hotel Red",
                    StreetAddress = "44 S 8th St",
                    City = "Seattle",
                    State = "Washington",
                    Phone = "206-648-5555",
                },
                 new Hotels
                {
                    ID = 4,
                    Name = "Hotel Cartmon",
                    StreetAddress = "954 W 7th St",
                    City = "Seattle",
                    State = "Washington",
                    Phone = "206-956-5555",
                },
                 new Hotels
                {
                    ID = 5,
                    Name = "Hotel Bebop",
                    StreetAddress = "888 E 89th St",
                    City = "Seattle",
                    State = "Washington",
                    Phone = "360-956-1235",
                });
            modelBuilder.Entity<Rooms>().HasData(
                new Rooms
                {
                    ID = 1,
                    Name = "Studio",
                    Layout = Models.Rooms.RoomLayout.Studio,
                },
                new Rooms
                {
                    ID = 2,
                    Name = "One Bedroom",
                    Layout = Models.Rooms.RoomLayout.OneBedroom,
                },
                new Rooms
                {
                    ID = 3,
                    Name = "Two Bedroom",
                    Layout = Models.Rooms.RoomLayout.TwoBedroom,
                },
                new Rooms
                {
                    ID = 4,
                    Name = "Penthouse",
                    Layout = Models.Rooms.RoomLayout.PentHouse,
                },
                new Rooms
                {
                    ID = 5,
                    Name = "Queen Suite",
                    Layout = Models.Rooms.RoomLayout.QueenSuite,
                },
                new Rooms
                {
                    ID = 6,
                    Name = "King Suite",
                    Layout = Models.Rooms.RoomLayout.KingSuite,
                });
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Balcony",
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Minibar",
                },
                new Amenities
                {
                    ID = 3,
                    Name = "Ocean View",
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Disco Ball",
                },
                new Amenities
                {
                    ID = 5,
                    Name = "Water Bed",
                });
        }

        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<HotelRooms> HotelRooms { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
    }
}

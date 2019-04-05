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
        }

        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<HotelRooms> HotelRooms { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
    }
}

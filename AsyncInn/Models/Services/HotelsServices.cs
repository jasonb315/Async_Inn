using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelsServices : IHotels
    {
        private AsyncInnDbContext _context;

        public void AmenetieService(AsyncInnDbContext context)
        {
            _context = context;
        }
        // [C]RUD
        // Create one
        public async Task CreateHotels(Hotels hotel)
        {
            _context.Add(hotel);
            await _context.SaveChangesAsync();
        }
        // C[R]UD
        // Check one
        public bool HotelsExists(int id)
        {
            return _context.Amenities.Any(x => x.ID == id);
        }
        // Read one
        public async Task<Hotels> GetHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return null;
            }
            return hotel;
        }
        // Read all
        public async Task<IEnumerable<Hotels>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        // CR[U]D
        public async Task UpdateHotels(int id, Hotels hotel)
        {
            _context.Update(hotel);
            await _context.SaveChangesAsync();
        }
        // CRU[D]
        public async Task DeleteHotels(int id)
        {
            Hotels hotel = await _context.Hotels.FindAsync(id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }
    }
}

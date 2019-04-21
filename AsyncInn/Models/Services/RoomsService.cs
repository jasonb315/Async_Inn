using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomsService : IRooms
    {
        private readonly AsyncInnDbContext _context;

        public RoomsService(AsyncInnDbContext context)
        {
            _context = context;
        }
        // [C]RUD
        // Create one
        public async Task CreateRooms(Rooms Room)
        {
            _context.Add(Room);
            await _context.SaveChangesAsync();
        }
        // C[R]UD
        // Check one
        public bool RoomsExists(int id)
        {
            return _context.Rooms.Any(x => x.ID == id);
        }
        // Read one
        public async Task<Rooms> GetRooms(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return null;
            }
            return room;
        }
        // Read all
        public async Task<List<Rooms>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        // CR[U]D
        public async Task UpdateRoom(int id, Rooms room)
        {
            _context.Update(room);
            await _context.SaveChangesAsync();
        }
        // CRU[D]
        public async Task DeleteRoom(int id)
        {
            Rooms room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConfirm(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}

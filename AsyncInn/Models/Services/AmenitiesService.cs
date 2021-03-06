﻿using AsyncInn.Models.Interfaces;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Models.Services
{
    public class AmenetiesService : IAmenities
    {
        private readonly AsyncInnDbContext _context;

        public AmenetiesService(AsyncInnDbContext context)
        {
            _context = context;
        }
        // [C]RUD
        // Create one
        public async Task CreateAmenitie(Amenities amenities)
        {
            _context.Add(amenities);
            await _context.SaveChangesAsync();
        }
        // C[R]UD
        // Check one
        public bool AmenitiesExists(int id)
        {
            return _context.Amenities.Any(x => x.ID == id);
        }
        // Read one
        public async Task<Amenities> GetAmenitie(int id)
        {
            var amenitie = await _context.Amenities.FindAsync(id);
            if (amenitie == null)
            {
                return null;
            }
            return amenitie;
        }
        // Read all
        public async Task<List<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        // CR[U]D
        public async Task UpdateAmenitie(int id, Amenities amenitie)
        {

            _context.Update(amenitie);
            await _context.SaveChangesAsync();
        }
        // CRU[D]
        public async Task DeleteAmenitie(int id)
        {
            Amenities amenitie = await _context.Amenities.FindAsync(id);
            _context.Amenities.Remove(amenitie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConfirm(int id)
        {
            var amenities = await _context.Amenities.FindAsync(id);
            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();
        }


    }
}

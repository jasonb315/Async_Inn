using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Models.Services
{
    public class AmenitiesService : IAmenities
    {
        private readonly AsyncInnDbContext _context;

        public AmenitiesServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create([Bind("ID,Name")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amenities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amenities);
        }

        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenities amenities)
        {
            if (id != amenities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amenities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenitiesExists(amenities.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(amenities);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenities = await _context.Amenities
                .FirstOrDefaultAsync(m => m.ID == id);
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenities = await _context.Amenities.FindAsync(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }




        // GIANT ANTS IN MY PANTS <3
    }
}

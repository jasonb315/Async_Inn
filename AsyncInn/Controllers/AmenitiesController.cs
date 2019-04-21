using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
    public class AmenitiesController : Controller
    {
        private readonly IAmenities _amenities;

        public AmenitiesController(IAmenities amenities)
        {
            _amenities = amenities;
        }

        // GET: Amenities
        public async Task<IActionResult> Index()
        {
            List<Amenities> amens = await _amenities.GetAmenities();
            return View(amens);
            // !
        }

        // GET: Amenities/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id.GetType() != typeof(int))
            {
                return NotFound();
            }

            //var amenities = await _context.Amenities
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (amenities == null)
            //{
            //    return NotFound();
            //}

            return View(await _amenities.GetAmenitie(id));
        }

        // GET: Amenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {
                await _amenities.CreateAmenitie(amenities);
                return RedirectToAction(nameof(Index));
            }
            return View(amenities);
        }

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id.GetType() != typeof(int))
            {
                return NotFound();
            }

            var a = await _amenities.GetAmenitie(id);

            //var amenitie = await _context.Amenities.FindAsync(id);
            if (a == null)
            {
                return NotFound();
            }
            return View(a);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    await _amenities.UpdateAmenitie(id, amenities);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenityPackageExists(amenities.ID))
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

        // GET: Amenities/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id.GetType() != typeof(int))
            {
                return NotFound();
            }

            var amenitie = await _amenities.GetAmenitie(id);

            if (amenitie == null)
            {
                return NotFound();
            }

            return View(amenitie);
        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _amenities.DeleteConfirm(id);
            return RedirectToAction(nameof(Delete));
        }

        private bool AmenityPackageExists(int id)
        {
            var amenitie = _amenities.AmenitiesExists(id);
            if (amenitie.GetType() != typeof(Amenities)) return true;
            return false;
        }
    }
}

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
    public class HotelsController : Controller
    {
        private readonly IHotels _hotels;

        public HotelsController(IHotels hotels)
        {
            _hotels = hotels;
        }

        // GET: Hotels
        public async Task<IActionResult> Index()
        {
            List<Hotels> hotels = await _hotels.GetHotels();
            return View(hotels);
        }

        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id.GetType() != typeof(int))
            {
                return NotFound();
            }

            return View(await _hotels.GetHotel(id));
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,StreetAddress,City,State,Phone")] Hotels hotels)
        {
            if (ModelState.IsValid)
            {
                await _hotels.CreateHotels(hotels);
                return View(hotels);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id.GetType() != typeof(int))
            {
                return NotFound();
            }

            var hotel = await _hotels.GetHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StreetAddress,City,State,Phone")] Hotels hotels)
        {
            if (id != hotels.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _hotels.UpdateHotels(id, hotels);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelsExists(hotels.ID))
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
            return View(hotels);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id.GetType() != typeof(int))
            {
                return NotFound();
            }

            var hotel = await _hotels.GetHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _hotels.DeleteConfirm(id);
            return RedirectToAction(nameof(Delete));
        }

        private bool HotelsExists(int id)
        {
            var hotel = _hotels.DeleteConfirm(id);
            if (hotel.GetType() != typeof(Hotels)) return true;
            return false;
        }
    }
}

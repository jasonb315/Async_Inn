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
    public class RoomsController : Controller
    {
        private readonly IRooms _rooms;

        public RoomsController(IRooms rooms)
        {
            _rooms = rooms;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            List<Rooms> rooms = await _rooms.GetRooms();
            return View(rooms);
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id.GetType() != typeof(int))
            {
                return NotFound();
            }

            return View(await _rooms.GetRooms(id));
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Layout")] Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                await _rooms.CreateRooms(rooms);
                return View(rooms);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id.GetType() != typeof(int))
            {
                return NotFound();
            }

            var room = await _rooms.GetRooms(id);

            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Layout")] Rooms rooms)
        {
            if (id != rooms.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _rooms.UpdateRoom(id, rooms);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomsExists(rooms.ID))
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
            return View(rooms);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id.GetType() != typeof(int))
            {
                return NotFound();
            }

            var room = await _rooms.GetRooms(id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rooms.DeleteConfirm(id);
            return RedirectToAction(nameof(Delete));
        }

        private bool RoomsExists(int id)
        {
            var room = _rooms.DeleteConfirm(id);
            if (room.GetType() != typeof(Rooms)) return true;
            return false;
        }
    }
}

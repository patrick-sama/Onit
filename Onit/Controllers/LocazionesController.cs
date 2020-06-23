using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Onit.Data;
using Onit.Models;

namespace Onit.Controllers
{
    public class LocazionesController : Controller
    {
        private readonly OnitContext _context;

        public LocazionesController(OnitContext context)
        {
            _context = context;
        }

        // GET: Locaziones
        public async Task<IActionResult> Index()
        {
            var onitContext = _context.Locazioni.Include(l => l.Area);
            return View(await onitContext.ToListAsync());
        }

        // GET: Locaziones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locazione = await _context.Locazioni
                .Include(l => l.Area)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locazione == null)
            {
                return NotFound();
            }

            return View(locazione);
        }

        // GET: Locaziones/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Aree, "Id", "Codice");
            return View();
        }

        // POST: Locaziones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codice,AreaId")] Locazione locazione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locazione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Aree, "Id", "Codice", locazione.AreaId);
            return View(locazione);
        }

        // GET: Locaziones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locazione = await _context.Locazioni.FindAsync(id);
            if (locazione == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Aree, "Id", "Codice", locazione.AreaId);
            return View(locazione);
        }

        // POST: Locaziones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codice,AreaId")] Locazione locazione)
        {
            if (id != locazione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locazione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocazioneExists(locazione.Id))
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
            ViewData["AreaId"] = new SelectList(_context.Aree, "Id", "Codice", locazione.AreaId);
            return View(locazione);
        }

        // GET: Locaziones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locazione = await _context.Locazioni
                .Include(l => l.Area)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locazione == null)
            {
                return NotFound();
            }

            return View(locazione);
        }

        // POST: Locaziones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locazione = await _context.Locazioni.FindAsync(id);
            _context.Locazioni.Remove(locazione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocazioneExists(int id)
        {
            return _context.Locazioni.Any(e => e.Id == id);
        }
    }
}

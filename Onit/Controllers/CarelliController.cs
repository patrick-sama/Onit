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
    public class CarelliController : Controller
    {
        private readonly OnitContext _context;

        public CarelliController(OnitContext context)
        {
            _context = context;
        }

        // GET: Carelloes
        public async Task<IActionResult> Index()
        {
            ViewBag.Locazione = await _context.Arrivi.Include(a => a.Carello)
                                                    .Include(a => a.Locazione)
                                                    .Include(a => a.Locazione.Area).ToListAsync();
            var carelli = await _context.ComponentiDeiCarelli
                        .Include(c=>c.Componente)
                        .Include(c => c.Carello)
                        .Include(s=>s.Carello.Arrivi)                       
                        .ToListAsync(); 
          
            return View(carelli);
        }

        // GET: Carelloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carello = await _context.Carelli
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carello == null)
            {
                return NotFound();
            }

            return View(carello);
        }

        // GET: Carelloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carelloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Matricola")] Carello carello)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carello);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carello);
        }

        // GET: Carelloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carello = await _context.Carelli.FindAsync(id);
            if (carello == null)
            {
                return NotFound();
            }
            return View(carello);
        }

        // POST: Carelloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Matricola")] Carello carello)
        {
            if (id != carello.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carello);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarelloExists(carello.Id))
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
            return View(carello);
        }

        // GET: Carelloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carello = await _context.Carelli
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carello == null)
            {
                return NotFound();
            }

            return View(carello);
        }

        // POST: Carelloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carello = await _context.Carelli.FindAsync(id);
            _context.Carelli.Remove(carello);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarelloExists(int id)
        {
            return _context.Carelli.Any(e => e.Id == id);
        }
    }
}

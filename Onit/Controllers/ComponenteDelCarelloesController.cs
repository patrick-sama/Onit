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
    public class ComponenteDelCarelloesController : Controller
    {
        private readonly OnitContext _context;

        public ComponenteDelCarelloesController(OnitContext context)
        {
            _context = context;
        }

        // GET: ComponenteDelCarelloes
        public async Task<IActionResult> Index()
        {
            var onitContext = _context.ComponentiDeiCarelli.Include(c => c.Carello).Include(c => c.Componente);
            return View(await onitContext.ToListAsync());
        }

        // GET: ComponenteDelCarelloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componenteDelCarello = await _context.ComponentiDeiCarelli
                .Include(c => c.Carello)
                .Include(c => c.Componente)
                .FirstOrDefaultAsync(m => m.CarelloId == id);
            if (componenteDelCarello == null)
            {
                return NotFound();
            }

            return View(componenteDelCarello);
        }

        // GET: ComponenteDelCarelloes/Create
        public IActionResult Create()
        {
            ViewData["CarelloId"] = new SelectList(_context.Carelli, "Id", "Matricola");
            ViewData["ComponenteId"] = new SelectList(_context.Componente, "Id", "Codice");
            return View();
        }

        // POST: ComponenteDelCarelloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Qty,CarelloId,ComponenteId")] ComponenteDelCarello componenteDelCarello)
        {
            if (ModelState.IsValid)
            {
                _context.Add(componenteDelCarello);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarelloId"] = new SelectList(_context.Carelli, "Id", "Matricola", componenteDelCarello.CarelloId);
            ViewData["ComponenteId"] = new SelectList(_context.Componente, "Id", "Codice", componenteDelCarello.ComponenteId);
            return View(componenteDelCarello);
        }

        // GET: ComponenteDelCarelloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componenteDelCarello = await _context.ComponentiDeiCarelli.FindAsync(id);
            if (componenteDelCarello == null)
            {
                return NotFound();
            }
            ViewData["CarelloId"] = new SelectList(_context.Carelli, "Id", "Matricola", componenteDelCarello.CarelloId);
            ViewData["ComponenteId"] = new SelectList(_context.Componente, "Id", "Codice", componenteDelCarello.ComponenteId);
            return View(componenteDelCarello);
        }

        // POST: ComponenteDelCarelloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Qty,CarelloId,ComponenteId")] ComponenteDelCarello componenteDelCarello)
        {
            if (id != componenteDelCarello.CarelloId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(componenteDelCarello);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponenteDelCarelloExists(componenteDelCarello.CarelloId))
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
            ViewData["CarelloId"] = new SelectList(_context.Carelli, "Id", "Matricola", componenteDelCarello.CarelloId);
            ViewData["ComponenteId"] = new SelectList(_context.Componente, "Id", "Codice", componenteDelCarello.ComponenteId);
            return View(componenteDelCarello);
        }

        // GET: ComponenteDelCarelloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componenteDelCarello = await _context.ComponentiDeiCarelli
                .Include(c => c.Carello)
                .Include(c => c.Componente)
                .FirstOrDefaultAsync(m => m.CarelloId == id);
            if (componenteDelCarello == null)
            {
                return NotFound();
            }

            return View(componenteDelCarello);
        }

        // POST: ComponenteDelCarelloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var componenteDelCarello = await _context.ComponentiDeiCarelli.FindAsync(id);
            _context.ComponentiDeiCarelli.Remove(componenteDelCarello);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponenteDelCarelloExists(int id)
        {
            return _context.ComponentiDeiCarelli.Any(e => e.CarelloId == id);
        }
    }
}

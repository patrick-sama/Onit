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
    public class ArrivisController : Controller
    {
        private readonly OnitContext _context;

        public ArrivisController(OnitContext context)
        {
            _context = context;
        }

        // GET: Arrivis
        public async Task<IActionResult> Index()
        {
            var onitContext = _context.Arrivi.Include(a => a.Carello).Include(a => a.Locazione);
            return View(await onitContext.ToListAsync());
        }

        // GET: Arrivis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrivi = await _context.Arrivi
                .Include(a => a.Carello)
                .Include(a => a.Locazione)
                .FirstOrDefaultAsync(m => m.CarelloId == id);
            if (arrivi == null)
            {
                return NotFound();
            }

            return View(arrivi);
        }

        // GET: Arrivis/Create
        public IActionResult Create()
        {
            ViewData["CarelloId"] = new SelectList(_context.Carelli, "Id", "Matricola");
            ViewData["LocazioneId"] = new SelectList((from s in _context.Locazioni.Include(s=>s.Area).ToList() select new
            {
                Id = s.Id,
                FullName = "Area {" +s.Area.Codice + "} Locazione {" + s.Codice +"}"
            }), "Id", "FullName");
           // ViewData["LocazioneId"] = new SelectList(_context.Locazioni, "Id", "Codice");

            return View();
        }

        // POST: Arrivis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descrizione,Date,CarelloId,LocazioneId")] Arrivi arrivi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arrivi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarelloId"] = new SelectList(_context.Carelli, "Id", "Matricola", arrivi.CarelloId);
            ViewData["LocazioneId"] = new SelectList(_context.Locazioni, "Id", "Codice", arrivi.LocazioneId);
            return View(arrivi);
        }

        // GET: Arrivis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrivi = await _context.Arrivi.FindAsync(id);
            if (arrivi == null)
            {
                return NotFound();
            }
            ViewData["CarelloId"] = new SelectList(_context.Carelli, "Id", "Matricola", arrivi.CarelloId);
            ViewData["LocazioneId"] = new SelectList(_context.Locazioni, "Id", "Codice", arrivi.LocazioneId);
            return View(arrivi);
        }

        // POST: Arrivis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Descrizione,Date,CarelloId,LocazioneId")] Arrivi arrivi)
        {
            if (id != arrivi.CarelloId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arrivi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArriviExists(arrivi.CarelloId))
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
            ViewData["CarelloId"] = new SelectList(_context.Carelli, "Id", "Matricola", arrivi.CarelloId);
            ViewData["LocazioneId"] = new SelectList(_context.Locazioni, "Id", "Codice", arrivi.LocazioneId);
            return View(arrivi);
        }

        // GET: Arrivis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrivi = await _context.Arrivi
                .Include(a => a.Carello)
                .Include(a => a.Locazione)
                .FirstOrDefaultAsync(m => m.CarelloId == id);
            if (arrivi == null)
            {
                return NotFound();
            }

            return View(arrivi);
        }

        // POST: Arrivis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arrivi = await _context.Arrivi.FindAsync(id);
            _context.Arrivi.Remove(arrivi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArriviExists(int id)
        {
            return _context.Arrivi.Any(e => e.CarelloId == id);
        }
    }
}

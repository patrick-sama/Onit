using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Onit.Data;
using Onit.Models;
using Onit.Other;

namespace Onit.Controllers
{
    public class ComponentesController : Controller
    {
        private readonly OnitContext _context;

        public ComponentesController(OnitContext context)
        {
            _context = context;
        }

        // GET: Componentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Componente.ToListAsync());
        }

        // GET: Componentes/AddOrEdit/5
        // GET: Componentes/AddOrEdit/
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Componente());
            }
            else
            {
                var componente = await _context.Componente.FindAsync(id);
                if (componente == null)
                {
                    return NotFound();
                }
                return View(componente);
            }
        }

        // POST: Componentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Codice,Descrizione,Note")] Componente componente)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(componente);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(componente);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ComponenteExists(componente.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Componente.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", componente) });
        }

        // GET: Componentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componente = await _context.Componente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (componente == null)
            {
                return NotFound();
            }

            return View(componente);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var componente = await _context.Componente.FindAsync(id);
            _context.Componente.Remove(componente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponenteExists(int id)
        {
            return _context.Componente.Any(e => e.Id == id);
        }
    }
}
